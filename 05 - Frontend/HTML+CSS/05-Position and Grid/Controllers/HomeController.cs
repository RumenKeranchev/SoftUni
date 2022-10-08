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
        
        public IActionResult SimpleLayout()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/simple-site-layout.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult PositionPlayground()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/position-playground.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult CenterTransform()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/center-position-and-transform.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Navigation()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/navigation.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult NewOffer()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/new-offer.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult SocialMediaIcons()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/social-media-icons.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult InteriorDesignStudio()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/interior-design-studio.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult Jewellery()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/jewellery-website.html"),
                ContentType = "text/html"
            };
        }
    }
}
