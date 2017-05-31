using System.Web.Mvc;
using HoidayResorts.DataContexts;

namespace HoidayResorts.Controllers
{
    public class HomeController : Controller
    {
        HolidayResortsDb _db = new HolidayResortsDb();

        //Home Page
        public ViewResult Index()
        {
            return View();
        }

        //Dispose database
        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();

            base.Dispose(disposing);
        }
    }
}