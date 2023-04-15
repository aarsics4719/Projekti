using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaOnline.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterService _CharactersService;
        private readonly IKorisniciService _KorisniciService;
        public CharacterController(ICharacterService charactersService, IKorisniciService korisniciService)
        {
            _CharactersService = charactersService;
            _KorisniciService = korisniciService;
        }

        public IActionResult Likovi()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var sviLikovi = _CharactersService.GetAll();
            return View("Character", sviLikovi);
        }

        [HttpGet]
        public IActionResult DodajLikove()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            return View("AddCharacter");
        }

        [HttpPost]
        public IActionResult DodajLikove(Likovi likovi)
        {
            if(ModelState.IsValid) 
            {
                _CharactersService.Add(likovi);
                return RedirectToAction(nameof(likovi));
            }
            else
            {
                return View("Likovi", likovi);
            }
        }

        //Character/delete/id
        [HttpGet]
        public IActionResult ObrisiLikove(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var data = _CharactersService.getById(id);
            return View("Delete", data);
        }

        [HttpPost]
        public IActionResult PotvrdiBrisanje(int id)
        {
            _CharactersService.Delete(id);
            return RedirectToAction(nameof(Likovi));
        }

        //character/edit/id
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var likovi = _CharactersService.getById(id);
            return View(likovi);
        }

        [HttpPost]
        public IActionResult Edit(int id, Likovi likovi)
        {
            likovi.LikoviId = id;
            _CharactersService.Update(id, likovi);
            return RedirectToAction(nameof(Likovi));
        }

    }
}
