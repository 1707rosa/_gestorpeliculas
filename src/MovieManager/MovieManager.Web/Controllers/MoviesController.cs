using Microsoft.AspNetCore.Mvc;

namespace MovieManager.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
