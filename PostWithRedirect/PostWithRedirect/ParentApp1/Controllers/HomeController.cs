using Microsoft.AspNetCore.Mvc;
using ParentApp1.Models;
using System.Diagnostics;
using ParentApp1.Models;

namespace ParentApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TokenModel tokenModel = new TokenModel() { Hiddenvalue = "This is a test value"};
            return View(tokenModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public HttpResponseMessage HandleRedirect()
        {
            StringContent content = new StringContent("This is test data");
            HttpResponseMessage result;
            using (var client = new HttpClient())
            {
                var postTask = client.PostAsync("https://localhost:7065/Home/HandlePostCall", content);
                postTask.Wait();
                result = postTask.Result;
            }
                return result;    
        }
    }
}