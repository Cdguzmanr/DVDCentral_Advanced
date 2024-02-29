using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using CG.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace CG.DVDCentral.UI.Controllers
{
    public class OrderController : GenericController<Order>
    {
        public OrderController(HttpClient httpClient) : base(httpClient) { }
    }
}

