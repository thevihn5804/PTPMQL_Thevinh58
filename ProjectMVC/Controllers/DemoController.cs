using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers;

public class DemoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
