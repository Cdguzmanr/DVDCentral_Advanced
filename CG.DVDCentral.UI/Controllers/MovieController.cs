using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Movies";
            return View(MovieManager.Load());
        }

        // Filter the Movie by ProgramId
        public IActionResult Browse(int id)
        {
            return View(nameof(Index), MovieManager.Load(id));
        }

        public IActionResult Details(int id)
        {
            var item = MovieManager.LoadById(id);
            ViewBag.Title = "Details";
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            try
            {
                int result = MovieManager.Insert(movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            return View(MovieManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie, bool rollback = false)
        {
            try
            {
                int result = MovieManager.Update(movie, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movie);
            }
        }

        public IActionResult Delete(int id)
        {
            return View(MovieManager.LoadById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Movie movie, bool rollback = false)
        {
            try
            {
                int result = MovieManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(movie);
            }
        }


    }
}
