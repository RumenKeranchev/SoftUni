using Microsoft.AspNetCore.Mvc;

namespace _04_CSS_Box_Model.Controllers
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
        
        public IActionResult First()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/01/index.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Second()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/02/index.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Third()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/03/index.html"),
                ContentType = "text/html"
            };
        }
    }
}
