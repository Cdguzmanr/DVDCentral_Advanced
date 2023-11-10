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
            ViewBag.Title = "List of Degree Types";
            return View(OrderManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = OrderManager.LoadById(id);

            // Load the Order View Model data
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);


            ViewBag.Title = "Details for order " + orderVM.Order.Id;
            return View(orderVM);
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
            var item = OrderManager.LoadById(id);

            // Load the Order View Model data
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);


            ViewBag.Title = "Edit " + orderVM.Order.Id;

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(orderVM);
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
                ViewBag.Title = "Edit order " + order.Id;
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = OrderManager.LoadById(id);

            // Load the Order View Model data
            OrderVM orderVM = new OrderVM();
            orderVM.Order = item;
            orderVM.OrderItems = OrderItemManager.LoadByOrderId(id);


            ViewBag.Title = "Delete order " + orderVM.Order.Id;
            return View(orderVM);
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
                ViewBag.Title = "Delete  order " + order.Id;
                ViewBag.Error = ex.Message;
                return View(order);
            }
        }


    }
}

