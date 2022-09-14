using Microsoft.AspNetCore.Mvc;

namespace _01_Intro_to_HTML_and_CSS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Welcome()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/welcome.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Fruits()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/fruits.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Wiki()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/wiki-page.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult ToDo()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/to-do-list.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Lists()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/html-lists.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Dls()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/definition-lists.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Rl()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/reversed-list.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Js()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/modern-javascript.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Book()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/book-story.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult News()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/world-cup-news.html"),
                ContentType = "text/html"
            };
        }
    }
}
