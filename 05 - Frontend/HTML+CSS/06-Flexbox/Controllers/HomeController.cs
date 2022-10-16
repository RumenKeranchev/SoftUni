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
        
        public IActionResult FlexboxLayout()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/flexbox-layout.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult FlexModelArticles()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/flex-model-articles.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult AbcGame()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/abc-game.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Calendar()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/calendar.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult NavigationFlexbox()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/navigation-flexbox.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult PhotoGalleryFlexbox()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/photo-gallery-flexbox.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult BlogLayoutFlexbox()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/navigation.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult StickyFooterFlexbox()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/sticky-footer-flexbox.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult CenterFlexbox()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/center-flexbox.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult ExpandingFlexCards()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/expanding-flex-cards.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Cards()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/cards.html"),
                ContentType = "text/html"
            };
        }
    }
}
