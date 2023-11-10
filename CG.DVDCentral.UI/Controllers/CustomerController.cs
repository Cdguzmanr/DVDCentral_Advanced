using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Customers";
            return View(CustomerManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create a Customer";

            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

            
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                int result = CustomerManager.Insert(customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create a Customer";
                ViewBag.Error = ex.Message;
                return View(customer);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Edit";

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(item);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

           
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Update(customer, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit";
                ViewBag.Error = ex.Message;
                return View(customer);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = CustomerManager.LoadById(id);
            ViewBag.Title = "Delete";
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, Customer customer, bool rollback = false)
        {
            try
            {
                int result = CustomerManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete";
                ViewBag.Error = ex.Message;
                return View(customer);
            }
        }


    }
}

