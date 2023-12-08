using Microsoft.AspNetCore.Mvc;

namespace CG.ProgDec.UI.ViewComponents
{
    public class ShoppingCartComponent : ViewComponent
    {

        public IViewComponentResult Invoke() // All it does is getting the program
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return View(HttpContext.Session.GetObject<ShoppingCart>("cart"));
            }
            else
            {
                return View(new ShoppingCart());
            }
        }
    }
}
