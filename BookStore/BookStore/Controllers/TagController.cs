using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}