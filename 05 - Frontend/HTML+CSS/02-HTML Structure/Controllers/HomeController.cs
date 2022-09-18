using Microsoft.AspNetCore.Mvc;

namespace _02_HTML_Structure.Controllers
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
        
        public IActionResult Nav()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/nav-bar.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Page()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/page-content.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Tags()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/semantic-tags.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Article()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/semantic-article.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Website()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/simple-website.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Blog()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/index.html"),
                ContentType = "text/html"
            };
        }
    }
}
