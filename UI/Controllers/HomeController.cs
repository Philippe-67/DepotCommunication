//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using UI.Models;

//namespace UI.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
// MicroserviceUI/Controllers/HomeController.cs
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MicroserviceUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _apiGatewayClient;
        private readonly IHttpClientFactory _httpClientFactory; 

        public HomeController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _apiGatewayClient = httpClientFactory.CreateClient();
            _apiGatewayClient.BaseAddress = new System.Uri(_configuration["ApiGatewayUrl"]);
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // Appel à l'API Gateway
            HttpResponseMessage response = await _apiGatewayClient.GetAsync("/api/rdv");

            // Traitement de la réponse, par exemple, récupérer le contenu JSON
            string responseData = await response.Content.ReadAsStringAsync();

            // Utiliser les données dans la vue ou autre traitement
            // ...

            return View();
        }
    }
}

