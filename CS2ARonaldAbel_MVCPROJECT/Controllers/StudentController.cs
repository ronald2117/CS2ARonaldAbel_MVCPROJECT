using CS2ARonaldAbel_MVCPROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Service;

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
    }

    
}
