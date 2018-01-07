using CodedUITestApplication.Shared.Models;
using System.Web.Mvc;

namespace CodedUITestApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CustomerModel());
        }

        public ActionResult Save()
        {
            return View();
        }
    }
}