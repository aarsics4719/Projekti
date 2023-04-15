using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaOnline.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _ActorsService;
        private readonly IKorisniciService _KorisniciService;

        public ActorsController(IActorsService actorsService, IKorisniciService korisniciService)
        {
            _ActorsService = actorsService;
            _KorisniciService = korisniciService;
        }

        public IActionResult Glumci()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var sviGlumci = _ActorsService.GetAll();
            return View("Actors",sviGlumci);
        }

        [HttpGet]
        public IActionResult DodajGlumca() 
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            return View("AddActor");
        }

        [HttpPost]
        public IActionResult DodajGlumca(Glumci glumci)
        {
            if(ModelState.IsValid)
            {
                _ActorsService.Add(glumci);
                return RedirectToAction(nameof(Glumci));
            }
            else
            {
                return View("Actors", glumci);
            }
        }

        

        [HttpGet]
        public IActionResult ObrisiGlumca(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var glumac = _ActorsService.GetById(id);
            return View("Delete", glumac);
        }


        [HttpPost]
        public IActionResult PotvrdiBrisanje(int id)
        {
            _ActorsService.Delete(id);
            return RedirectToAction(nameof(Glumci));
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var glumac = _ActorsService.GetById(id);
            return View(glumac);
        }

        [HttpPost]
        public IActionResult Edit(int id, Glumci glumac)
        {
            glumac.GlumciId = id;
            _ActorsService.Update(id, glumac);
            return RedirectToAction(nameof(Glumci));
        }
    }
}
