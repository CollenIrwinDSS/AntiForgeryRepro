using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace AntiForgeryRepro.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
        public async Task<ActionResult> Page()
        {
            // Delay here simulates work being done
            await Task.Delay(150);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostPage()
        {
            return RedirectToAction(nameof(Page));
        }
    }
}
