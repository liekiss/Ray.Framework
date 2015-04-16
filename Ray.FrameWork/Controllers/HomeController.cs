using Application;
using Domain.Models;
using System.Web.Mvc;

namespace Ray.FrameWork.Controllers
{
    public class HomeController : Controller
    {
        TestApplication _application;
        public HomeController(TestApplication application)
        {
            _application = application;
        }

        public ActionResult Index()
        {
            Students s = new Students { Address = "测试3", Age = 22, StuName = "Ray1" };
            _application.AddStudent(s);
            var s1 = _application.GetAllStudents();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}