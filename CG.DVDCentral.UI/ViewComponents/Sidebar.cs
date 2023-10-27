using CG.DVDCentral.BL;
using CG.DVDCentral.BL.Models;
using Microsoft.AspNetCore.Mvc;
namespace CG.DVDCentral.UI.ViewComponents
{
    public class Sidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GenreManager.Load().OrderBy(p => p.Description));
        }
    }
}