using GCDealershipWebApp.Models;
using GCDealershipWebApp.Service;
using GCDealershipWebApp.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GCDealershipWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDealerService _service;

        public HomeController(ILogger<HomeController> logger, IDealerService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetDataAsync();
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _service.Search(query);
            return View(result); 
        }

        //[HttpPost]
        //public async Task<IActionResult> SearchYear(int year)
        //{
        //    var result = await _service.SearchYear(year);
        //    return View(result);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
