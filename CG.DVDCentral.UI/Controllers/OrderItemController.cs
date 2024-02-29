using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class OrderItemController : GenericController<OrderItem>
    {
        public OrderItemController(HttpClient httpClient) : base(httpClient) { }
    }
}
