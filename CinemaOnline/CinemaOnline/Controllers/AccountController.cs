using Azure.Identity;
using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaOnline.Controllers
{
    public class AccountController : Controller
    {
        private readonly IKorisniciService _KorisniciService;

        public AccountController(IKorisniciService korisniciService)
        {
            _KorisniciService = korisniciService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Korisnici korisnik)
        {
            if (ModelState.IsValid)
            {
                _KorisniciService.Add(korisnik);
                return RedirectToAction(nameof(Login));
            }
            return View(korisnik);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Korisnici korisnik)
        {
            if (ModelState.IsValid)
            {
                var user = _KorisniciService.GetByEmailAndPassword(korisnik);
                if (user == null)
                {
                    return null;
                }
                else
                {
                    HttpContext.Session.SetInt32("Sesija", user.KorisniciId);
                    return RedirectToAction("Index","Home");
                }
            }
            return View(korisnik);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Sesija");
            return RedirectToAction(nameof(Login));
        }
    }
}