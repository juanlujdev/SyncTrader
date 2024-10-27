using Microsoft.AspNetCore.Mvc;

namespace SyncTrader.Controllers
{
    public class Action : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
