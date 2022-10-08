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
        
        public IActionResult Box()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/box-model-container.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Scrolling()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/scrolling-article.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Coffee()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/brazil-coffee.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Article()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/article.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Blog()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/blog-article.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Nav()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/navigation-inline-block.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Web()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/make-your-olwn-website.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Gallery()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/gallery.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Layout()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/index.html"),
                ContentType = "text/html"
            };
        }
    }
}
