using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new Student());
    }

    [HttpPost]
    public IActionResult Index(Student student)
    {
        ViewBag.ThongBao = "Xin chao: " + student.fullName + "- Ma sinh vien: " + student.studentNumber;
        return View(student);
    }
}
