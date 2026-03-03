using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers;

public class DemoController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.Title = "Trang chủ";
        ViewBag.Message = "Chào mừng bạn đến với MVC";
        ViewBag.Count = 5;

        return View();
    }
}
