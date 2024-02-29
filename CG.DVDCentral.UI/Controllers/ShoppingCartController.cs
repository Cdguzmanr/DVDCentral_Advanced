using CG.DVDCentral.UI.Models;
using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : GenericController<ShoppingCart>
    {
        public ShoppingCartController(HttpClient httpClient) : base(httpClient) { }
    }
}
