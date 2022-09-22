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
                Content = System.IO.File.ReadAllText("./Views/Home/buttons-css.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Speciment()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/fonts-speciment.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Colors()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/contrasting-colors.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Font()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/making-css-font.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult FontIcons()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/font-awesome-icons.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult ButtonIcons()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/icon-font-buttons.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult ListIcons()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/icon-font-list.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Typography()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/typography.html"),
                ContentType = "text/html"
            };
        }
    }
}
