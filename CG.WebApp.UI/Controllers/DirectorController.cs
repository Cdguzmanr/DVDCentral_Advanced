using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.WebApp.UI.Controllers
{
    public class DirectorController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {

            ViewBag.Title = "List of Directors";
            return View(new DirectorManager.Load());
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Details for Director " + item.Id;

            return View(item);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Title = "Create a Director";

            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            try
            {
                int result = DirectorManager.Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Edit";

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(item);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

        }

        [HttpPost]
        public IActionResult Edit(int id, Director director, bool rollback = false)
        {
            try
            {
                int result = DirectorManager.Update(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(DirectorManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Director director, bool rollback = false)
        {
            try
            {
                int result = DirectorManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }


    }
}
