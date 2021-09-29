using Microsoft.AspNetCore.Mvc;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}