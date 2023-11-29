using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace CG.DVDCentral.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Orders";
            return View(OrderManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = OrderManager.LoadById(id);

            // Load the Order View Model data

            /*  // Use Order View Model
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);
            */


            ViewBag.Title = "Details for Order " + item.Id;
            return View(item);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create a Order";

            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

            
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            try
            {
                int result = OrderManager.Insert(order);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create a Order";
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }

        public IActionResult Edit(int id)
        {
            

            // Load the Order View Model data
            /* // Use Order View Model
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);
            */


            var item = OrderManager.LoadById(id);
            ViewBag.Title = "Edit Order " + item.Id;

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(item);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 


        }

        [HttpPost]
        public IActionResult Edit(int id, Order order, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Update(order, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit Order " + order.Id;
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }

        public IActionResult Delete(int id)
        {
            

            // Load the Order View Model data
            /* // Use Order View Model
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);
            */
            var item = OrderManager.LoadById(id);
            ViewBag.Title = "Delete Order " + item.Id;
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, Order order, bool rollback = false)
        {
            try
            {
                int result = OrderManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete  Order " + order.Id;
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }


    }
}

