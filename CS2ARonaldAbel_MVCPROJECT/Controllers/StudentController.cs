using CS2ARonaldAbel_MVCPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Service;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace CS2ARonaldAbel_MVCPROJECT.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService = new StudentService();

        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        public IActionResult AddStudent(tblStudent student)
        {
            return View(student);
        }

        [HttpPost]
        public IActionResult AddStudentFormSubmit(tblStudent student)
        {
            try
            {
                if (student == null)
                {
                    return Json(new { success = false, message = "Invalid student data provided." });
                }

                bool result = _studentService.Add(student);

                if (result)
                {   
                    return Json(new { success = true, message = "Student added successfully." });
                }   
                else
                {
                    return Json(new { success = false, message = "Failed to add the student. Please try again." });
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle database-related errors
                return Json(new { success = false, message = $"Database error: {sqlEx.Message}" });
            }
            catch (ValidationException valEx)
            {
                // Handle validation errors
                return Json(new { success = false, message = $"Validation error: {valEx.Message}" });
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                return Json(new { success = false, message = $"An unexpected error occurred: {ex.Message}" });
            }
        }


        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Student ID provided.");
            }

            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return View(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving student data for editing.");
            }
        }
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                bool result = _studentService.Delete(id);

                if (result)
                {
                    TempData["AlertMessage"] = "Student deleted successfully.";
                }
                else
                {
                    TempData["AlertMessage"] = "Failed to delete the student. Please try again.";
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle database-related errors
                TempData["AlertMessage"] = $"Database error: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                TempData["AlertMessage"] = $"An unexpected error occurred: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
        public IActionResult UpdateStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                TempData["AlertMessage"] = "Student not found.";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudentFormSubmit(tblStudent student)
        {
            try
            {
                if (student == null)
                {
                    return Json(new { success = false, message = "Invalid student data provided." });
                }

                bool result = _studentService.Update(student);

                if (result)
                {
                    return Json(new { success = true, message = "Student updated successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to update the student. Please try again." });
                }
            }
            catch (SqlException sqlEx)
            {
                // Handle database-related errors
                return Json(new { success = false, message = $"Database error: {sqlEx.Message}" });
            }
            catch (ValidationException valEx)
            {
                // Handle validation errors
                return Json(new { success = false, message = $"Validation error: {valEx.Message}" });
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                return Json(new { success = false, message = $"An unexpected error occurred: {ex.Message}" });
            }
        }
        
        

    }}
