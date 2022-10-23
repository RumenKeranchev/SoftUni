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
        
        public IActionResult Navigation()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/navigation.html"),
                ContentType = "text/html"
            };
        }
        
        public IActionResult ResponsiveForms()
        {
            return new ContentResult
            {
                Content = System.IO.File.ReadAllText("./Views/Home/responsive-forms.html"),
                ContentType = "text/html"
            };
        }
    }
}
