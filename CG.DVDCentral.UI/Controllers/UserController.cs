using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Extensions;
using CG.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View(UserManager.Load());
        }


        public IActionResult Seed()
        {
            UserManager.Seed();
            return View();
        }

        private void SetUser(User user)
        {

            HttpContext.Session.SetObject("user", user);
            if (user != null)
            {
                HttpContext.Session.SetObject("fullname", "Welcome " + user.FullName);
            }
            else
            {
                HttpContext.Session.SetObject("fullname", string.Empty);
            }
        }
        public IActionResult Logout()
        {
            ViewBag.Title = "Logout";
            SetUser(null);
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            ViewBag.Title = "Login";
            return View();        
        }
        
     
        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                bool result = UserManager.Login(user);
                SetUser(user);

                if (TempData["returnUrl"] != null)
                {
                    return Redirect(TempData["returnUrl"]?.ToString());
                }

                return RedirectToAction(nameof(Index), "Order"); // ALWAYS Change default re-derict page 
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Login";
                ViewBag.Error = ex.Message;
                throw;
            }
        }

        

        // --- Checkpoint 5 ----- //

        public IActionResult Create()
        {
            ViewBag.Title = "Create User";
            /*
            if (Authenticate.IsAuthenticated(HttpContext))
                return View();
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 
            */
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                int result = UserManager.Insert(user); // Insert the user in DB
                SetUser(user); // LogIn with new user 

                return RedirectToAction(nameof(Index)); // Redirect to Index after creating a user
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Create User";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                User user = UserManager.LoadById(id);
                ViewBag.Title = "Edit User";

                if (Authenticate.IsAuthenticated(HttpContext))
                    return View(user);
                else
                    return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); // Still need to add "Login" 

               
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit User";
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                int result = UserManager.Update(user);
                SetUser(user);

                return RedirectToAction(nameof(Index)); // Redirect to Order Index after editing a user
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Edit User";
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

    }
        
}
