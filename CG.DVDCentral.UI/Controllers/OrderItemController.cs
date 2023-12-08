using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
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

        public IActionResult Remove(int id, bool rollback = false)
        {
            try
            {
                int result = OrderItemManager.Delete(id, rollback);
                return RedirectToAction("Index", "Order");
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete item for Order " + id;
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
