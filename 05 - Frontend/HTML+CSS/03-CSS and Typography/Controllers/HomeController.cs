using Microsoft.AspNetCore.Mvc;

namespace _03_CSS_and_Typography.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/Home.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Menu()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/restaurant-menu.html"),
                ContentType = "text/html"
            };
        }

        public IActionResult Lists()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/style-lists.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Tables()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/styling-tables.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Buttons()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/index.html"),
                ContentType = "text/html"
            };
        }
    }
}
