using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class DirectorController : GenericController<Director>
    {
       public DirectorController(HttpClient httpClient) : base(httpClient) { }
    }
}
