using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using CG.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CG.DVDCentral.UI.Controllers
{
    public class GenreController : GenericController<Genre>
    {
        public GenreController(HttpClient httpClient) : base(httpClient) { }
    }
}

