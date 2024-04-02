using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL2.Data;
//using CG.DVDCentral.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CG.WebApp.UI.Controllers
{
    public class DirectorController : Controller
    {
        private readonly DbContextOptions<DVDCentralEntities> options;

        public DirectorController(ILogger<DirectorController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.Title = "Directors";
            ViewBag.Info = TempData["info"];
            return View(new DirectorManager(options).Load());
        }

        [AllowAnonymous]
        public IActionResult Details(Guid id)
        {
            Director director = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Director Details - " + director.FirstName + " " + director.LastName;
            return View(director);
        }

        [Authorize]
        public IActionResult Create()
        {

            ViewBag.Title = "Create Director";
            return View();

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Director director)
        {
            try
            {
                Guid result = new DirectorManager(options).Insert(director);
                ViewBag.Title = "Create Director";
                TempData["info"] = result + " director added.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create Director";
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }

        public IActionResult Edit(Guid id)
        {

            Director director = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Edit Director - " + director.FirstName + " " + director.LastName;
            return View(director);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Director director)
        {
            try
            {
                int result = new DirectorManager(options).Update(director);
                ViewBag.Title = "Edit Director - " + director.FirstName + " " + director.LastName;
                TempData["info"] = result + " director updated.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit Director - " + director.FirstName + " " + director.LastName;
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }

        public IActionResult Delete(Guid id)
        {
            Director director = new DirectorManager(options).LoadById(id);
            ViewBag.Title = "Delete Director - " + director.FirstName + " " + director.LastName;
            return View(director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, Director director)
        {
            try
            {
                int result = new DirectorManager(options).Delete(id);
                ViewBag.Title = "Delete Director - " + director.FirstName + " " + director.LastName;
                TempData["info"] = "Director \"" + director.FullName + "\" was deleted.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Delete Director - " + director.FirstName + " " + director.LastName;
                ViewBag.Error = ex.Message;
                return View(director);
            }
        }


    }
}
