using CS2ARonaldAbel_MVCPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Service;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Model;

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
        public IActionResult AddStudent(tblStudent student)
        {
            try
            {
                bool result = _studentService.Add(student);
                return Json(new {success = result, message = result ? "Student added succesfully" : "Failed"});
            } 
            catch (Exception ex) 
            {
                return Json(new {success = false, message = ex.Message});
            }
        }
    }

    
}
