using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Ratings";
            return View(RatingManager.Load());
        }

        public IActionResult Details(int id)
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Details for Rating " + item.Id;

            return View(item);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create a Rating";

            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

        }

        [HttpPost]
        public IActionResult Create(Rating rating)
        {
            try
            {
                int result = RatingManager.Insert(rating);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create a Rating";
                ViewBag.Error = ex.Message;
                return View(rating);
            }
        }

        public IActionResult Edit(int id)
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Edit rating " + item.Id;

            if (Authenticate.IsAuthenticated(HttpContext))
                return View(item);
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); 

        }

        [HttpPost]
        public IActionResult Edit(int id, Rating rating, bool rollback = false)
        {
            try
            {
                int result = RatingManager.Update(rating, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit rating " + rating.Id;
                ViewBag.Error = ex.Message;
                return View(rating);
            }
        }

        public IActionResult Delete(int id)
        {
            var item = RatingManager.LoadById(id);
            ViewBag.Title = "Delete rating " + item.Id;
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(int id, Rating rating, bool rollback = false)
        {
            try
            {
                int result = RatingManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete  rating " + rating.Id;
                ViewBag.Error = ex.Message;
                return View(rating);
            }
        }


    }
}
