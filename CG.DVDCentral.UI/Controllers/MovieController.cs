using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;


namespace CG.DVDCentral.UI.Controllers
{
    public class MovieController : Controller
    {

        private readonly IWebHostEnvironment _host;
        public MovieController(IWebHostEnvironment host)
        {
            _host = host;
        }

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
            var movieVM = new MovieVM();
            return View(movieVM);
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
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                // Using Constructor with Id since its calling all loads
                MovieVM movieVM = new MovieVM(id);
                ViewBag.Title = "Edit " + movieVM.Movie.Title;
                HttpContext.Session.SetObject("genreids", movieVM.GenreIds);
                return View(movieVM);
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });

        }

        [HttpPost]
        public IActionResult Edit(int id, MovieVM movieVM, bool rollback = false)
        {
            try
            {

                // Process the image
                if (movieVM.File != null) // Error doing populate of image. Its always null
                {
                    movieVM.Movie.ImagePath = movieVM.File.FileName;

                    string path = _host.WebRootPath + "\\images\\";

                    using (var stream = System.IO.File.Create(path + movieVM.File.FileName)) // You are going to process the characters enconded in the image
                    {
                        movieVM.File.CopyTo(stream);

                        ViewBag.Message = "File Uploaded Successfully...";
                    }
                }

                // Insert MovieGenre

                IEnumerable<int> newGenreIds = new List<int>();
                if (movieVM.GenreIds != null)
                    newGenreIds = movieVM.GenreIds;

                IEnumerable<int> oldGenreIds = new List<int>();
                oldGenreIds = GetObject();

                IEnumerable<int> deletes = oldGenreIds.Except(newGenreIds);
                IEnumerable<int> adds = newGenreIds.Except(oldGenreIds);

                deletes.ToList().ForEach(d => MovieGenreManager.Delete(id, d));
                adds.ToList().ForEach(a => MovieGenreManager.Insert(id, a));

                /*
                foreach (var genreId in newGenreIds)
                {
                    MovieGenreManager.Update(id, genreId, rollback);
                }
                */


                // Insert Movie Object
                int result = MovieManager.Update(movieVM.Movie, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit " + movieVM.Movie.Title;
                ViewBag.Error = ex.Message;
                return View(movieVM);
            }
        }

        private IEnumerable<int> GetObject()
        {
            if (HttpContext.Session.GetObject<IEnumerable<int>>("genreids") != null)
            {
                return HttpContext.Session.GetObject<IEnumerable<int>>("genreids");
            }
            else
            {
                return null;
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
