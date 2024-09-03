using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentList()
        {
            var studentList = students.ToList();
            var studentJson = JsonConvert.SerializeObject(studentList);
            return Json(studentJson);
        }

        public IActionResult GetStudentById(int studentId)
        {
            var student = students.FirstOrDefault(i => i.Id == studentId);
            var studentJson = JsonConvert.SerializeObject(student);
            return Json(studentJson);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if(student != null)
            {
                students.Add(student);
                var studentJson = JsonConvert.SerializeObject(student);
                return Json(studentJson);
            }else { return View(); }
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            var studentM = students.FirstOrDefault(i => i.Id == student.Id);

            if (studentM != null)
            {
                studentM.Name = student.Name;
                studentM.Gender = student.Gender;
                studentM.Age = student.Age;

                var studentJson = JsonConvert.SerializeObject(student);
                return Json(studentJson);
            }
            else { return View(); }
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            var student = students.FirstOrDefault(i => i.Id == studentId);

            if (student != null)
            {
                students.Remove(student);
                var studentJson = JsonConvert.SerializeObject(student);
                return Json(studentJson);
            }
            else { return View(); }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static List<Student> students = new List<Student>()
        {
                new Student() { Id =1,Name = "Suresh Dasari", Gender = "Female",Age=20 },
                new Student() { Id =2,Name = "Rohini Alavala", Gender = "Male", Age=35 },
                new Student() { Id =3,Name = "Praveen Alavala", Gender = "Female",Age=20 },
                new Student() { Id =4,Name = "Sateesh Alavala", Gender = "Male", Age =35},
                new Student() { Id =5,Name = "Adrian Sai", Gender = "Male", Age=35},
                new Student() { Id =6,Name = "Alvin Dustin", Gender = "Male", Age=35},
                new Student() { Id =7,Name = "Axel Sai", Gender = "Female", Age=20},
                new Student() { Id =8,Name = "Brice Dustin", Gender = "Female", Age=20},
        };
    }

   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }

}
