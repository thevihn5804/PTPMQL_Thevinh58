using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Net;
namespace ProjectMVC.Controllers;
public class StudentController : Controllers
{
    [HttpGet]
    public ActionResult Index()
    {
        return View(new Student());
    }

    [HttpPost]
    public Actionresult Index(Student student)
    {
        ViewBag.ThongBao = "Xin chao: " +student.fullName + "- Ma sinh vien: " + student.studentNumber;
        return View(student);
    }
}
