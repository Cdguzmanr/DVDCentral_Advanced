using CG.DVDCentral.BL;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Order Items";
            return View(OrderItemManager.Load());
        }
    }
}
