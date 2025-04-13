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

        public IActionResult AddNewStudent()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult AddStudent(tblStudent student)
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

        public IActionResult EditStudent()
        {
            return View();
        }
    }}
