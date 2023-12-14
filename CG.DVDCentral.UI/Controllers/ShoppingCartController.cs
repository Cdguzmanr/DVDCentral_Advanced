using CG.DVDCentral.UI.Models;
using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;


        // GET: ShoppingCartController
        public ActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();
            Movie movie = cart.Items.FirstOrDefault(x => x.Id == id);
            ShoppingCartManager.Remove(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Movie movie = MovieManager.LoadById(id);
            ShoppingCartManager.Add(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index), "Movie");
        }

        public IActionResult Checkout(int id)
        {

            if (Authenticate.IsAuthenticated(HttpContext))
            {
                cart = GetShoppingCart();

                ShoppingCartManager.Checkout(cart);
                HttpContext.Session.SetObject("cart", null);

                return View();
            }
            else
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) }); 
            
        }



        // Checkpoint 8


        // Get
        public ActionResult AssignToCustomer()
        {
            ViewBag.Title = "Assign a Customer";

            // First verify if there is a user on session
            if (!Authenticate.IsAuthenticated(HttpContext))
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
               

            // Get the user from Session
            var user = HttpContext.Session.GetObject<User>("user");

            // Instantiate a new instance of the CustomerViewModel view model
            CustomerViewModel customerVM = new CustomerViewModel();

            // Instantiate a new instance of Customer object.
            Customer customer = new Customer();

            // Get and put the cart inte the ViewModel
            cart = GetShoppingCart();
            customerVM.Cart = cart;

            // Set the UserId in the ViewModel
            customerVM.UserId = user.Id;

            // Load ViewModel.Customers list.
            customerVM.Customers = CustomerManager.LoadByUserId(customerVM.UserId); 


            // if the UserId has any customers, set the ViewModel.CustomerId to the first one. Could have more than one.
            if (customerVM.Customers.Count > 0)
            {
                customerVM.CustomerId = customerVM.Customers[0].Id;
            }
            else if (customerVM.Customers.Count <= 0)
            {
                customerVM.Customers = CustomerManager.Load();
                customerVM.CustomerId = customerVM.Customers.FirstOrDefault().Id;    
            }

            // Put the ViewModel in session.
            HttpContext.Session.SetObject("customerVM", customerVM);

            // Set the ViewData["ReturnUrl"] to the Urihelper.GetDisplayUrl(HttpContext.Request);
            ViewData["ReturnUrl"] = UriHelper.GetDisplayUrl(HttpContext.Request);

            // return the view with viemodel as the model
            return View(customerVM);
        }


        // Post
        [HttpPost]
        public ActionResult AssignToCustomer(CustomerViewModel customerVM)
        {


            try
            {
                ViewBag.Title = "Assign a Customer";
                 
                // Todo: 
                cart = GetShoppingCart();
                customerVM.Cart = cart;



                /* Order order = new Order();
                order.CustomerId = cartCustomers.CustomerId;
                order.UserId = cartCustomers.UserId;
                cartCustomers.Cart.Items.ForEach(x => order.OrderItems.Add(new OrderItem {  OrderId = order.Id,
                                                                                                    MovieId = x.Id,
                                                                                                    Cost = x.Cost,
                                                                                                    Quantity = x.Quantity }));  
                OrderManager.Insert(order); */

                ShoppingCartManager.Checkout(cart, customerVM.CustomerId, customerVM.UserId);

                HttpContext.Session.SetObject("cart", null);
                return View(nameof(Checkout));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(customerVM);
            }
            
        }
        
        


    }
}
