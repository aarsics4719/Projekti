using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Mvc;


namespace CinemaOnline.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _MoviesService;
        private readonly IActorsService _ActorsService;
        private readonly ICharacterService _CharacterService;
        private readonly IKorisniciService _KorisniciService;

        public MoviesController(IMoviesService service, IActorsService actorsService, ICharacterService characterService, IKorisniciService korisniciService)
        {
            _MoviesService = service;
            _ActorsService = actorsService;
            _CharacterService = characterService;
            _KorisniciService = korisniciService;
        }
        public IActionResult MoviesAdmin()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var movies = _MoviesService.GetAll();
            return View(movies);
        }

        public IActionResult Movies()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;


            var sviFilmovi = _MoviesService.GetAll();
            return View("Movies", sviFilmovi);
        }


        public IActionResult Search(string search)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            ViewData["Filter"] = search;

            var movies = _MoviesService.GetAll();

            if(!String.IsNullOrEmpty(search) )
            {
                movies = movies.Where(m => m.Ime.Contains(search) || m.Zanr.Contains(search));
            }
            return View("Movies",movies);
        }


        [HttpGet]
        public IActionResult DodajFilm()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            ViewBag.Actors = _ActorsService.GetAll();
            ViewBag.Characters = _CharacterService.GetAll();

            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult DodajFilm(Filmovi filmovi, int[] Glumci, int[] Likovi)
        {
            if (ModelState.IsValid)
            {
                _MoviesService.Add(filmovi);

                if (Glumci != null && Likovi != null)
                {
                    foreach (var glumciId in Glumci)
                    {
                        foreach (var likoviId in Likovi)
                        {
                            var film = new Filmovi
                            {
                                FilmId = filmovi.FilmId,
                                LikoviId = likoviId,
                                GlumciId = glumciId,
                            };
                            _MoviesService.Add(film);
                        }
                    }
                }
                return RedirectToAction(nameof(MoviesAdmin));
            }
            ViewBag.Actors = _ActorsService.GetAll();
            ViewBag.Characters = _CharacterService.GetAll();

            return View(filmovi);
        }

        [HttpGet]
        public IActionResult ObrisiFilm(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var film = _MoviesService.GetById(id);
            return View("Delete", film);
        }


        [HttpPost]
        public IActionResult PotvrdiBrisanje(int id)
        {
            _MoviesService.Delete(id);
            return RedirectToAction(nameof(MoviesAdmin));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            ViewBag.Actors = _ActorsService.GetAll();
            ViewBag.Characters = _CharacterService.GetAll();
            var film = _MoviesService.GetById(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(int id, Filmovi film)
        {
            film.FilmId = id;
            _MoviesService.Update(id, film);
            return RedirectToAction(nameof(MoviesAdmin));
        }
    }
}
