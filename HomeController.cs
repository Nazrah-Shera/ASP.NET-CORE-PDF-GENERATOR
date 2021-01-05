using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PDF.Models;
using PDF.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _oHostEnvironment;

        public HomeController(IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult PrintStudent(int param)
        {
            List<Student> oStudents = new List<Student>();
            for(int i = 1; i <= 10; i++)
            {
                Student oStudent = new Student();
                oStudent.Id = i;
                oStudent.Name = "Student" + i;
                oStudent.Address = "Address" + i;
                oStudents.Add(oStudent);
            }
            StudentReport rpt = new StudentReport(_oHostEnvironment);
            return File(rpt.Report(oStudents), "application/pdf");
        }
        
    }
}
