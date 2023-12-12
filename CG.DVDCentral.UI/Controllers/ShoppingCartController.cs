using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http;
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
            cart = GetShoppingCart();
            ShoppingCartManager.Checkout(cart);
            HttpContext.Session.SetObject("cart", null);
            return View();
        }



        // Checkpoint 8
        [HttpPost]
        public ActionResult AssignToCustomer(CustomerViewModel cartCustomers)
        {


            try
            {
                // Todo: 
                cartCustomers.ShoppingCart = GetShoppingCart();

                Order order = new Order();
                order.CustomerId = cartCustomers.Customer.Id;
                order.UserId = cartCustomers.Customer.UserId;
                cartCustomers.ShoppingCart.Items.ForEach(x => order.OrderItems.Add(new OrderItem {  OrderId = order.Id,
                                                                                                    MovieId = x.Id,
                                                                                                    Cost = x.Cost,
                                                                                                    Quantity = x.Quantity }));  
                OrderManager.Insert(order);
                HttpContext.Session.SetObject("cart", cart);
                return View();

            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}
