using System.Web.Mvc;

namespace HoidayResorts.Controllers
{
    public class HomeController : Controller
    {
        //Home Page
        public ViewResult Index()
        {
            return View();
        }
    }
}
