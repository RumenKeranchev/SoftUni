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
    }
}
