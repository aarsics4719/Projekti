using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CinemaOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKorisniciService _KorisniciService;
        public HomeController(ILogger<HomeController> logger,IKorisniciService korisniciService)
        {
            _logger = logger;
            _KorisniciService = korisniciService;
        }

        public IActionResult Index()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}