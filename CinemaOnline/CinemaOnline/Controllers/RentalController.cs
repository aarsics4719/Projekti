using CinemaOnline.Models;
using CinemaOnline.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CinemaOnline.Controllers
{
    public class RentalController : Controller
    {
        private readonly IMoviesService _MoviesService;
        private readonly IActorsService _ActorsService;
        private readonly ICharacterService _CharacterService;
        private readonly IRentalService _RentalService;
        private readonly IKorisniciService _KorisniciService;
        private readonly IRatingService _RatingService;
        private readonly MovieRentalContext _context;

        public RentalController(IMoviesService moviesService, IActorsService actorsService, ICharacterService characterService, IRentalService rentalService, IRatingService ratingService, MovieRentalContext context, IKorisniciService korisniciService)
        {
            _MoviesService = moviesService;
            _ActorsService = actorsService;
            _CharacterService = characterService;
            _RentalService = rentalService;
            _KorisniciService = korisniciService;
            _RatingService = ratingService;
            _context = context;
        }



        [HttpGet]
        public IActionResult RentalDetails(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            ViewBag.Actors = _ActorsService.GetAll();
            ViewBag.Characters = _CharacterService.GetAll();


            var film = _MoviesService.GetById(id);
            ViewBag.ActorId = film.GlumciId;
            ViewBag.CharacterId = film.LikoviId;

            var rejtingViewModel = new RejtingViewModel
            {
                FilmId = film.FilmId,
                Ime = film.Ime,
                Slika = film.Slika,
                Godina = film.Godina,
                Trajanje = film.Trajanje,
                Zanr = film.Zanr,
                Opis = film.Opis,
                Cena = film.Cena,
                Ocena = film.Ocena
            };

            var comments = _RatingService.GetAll().Where(r => r.FilmId == id);
            ViewBag.Comments = comments;
            return View(rejtingViewModel);
        }

        [HttpPost]
        public IActionResult AddRating(RejtingViewModel rejtingViewModel)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var existingRejting = _RatingService.GetByFilmAndUser(rejtingViewModel.FilmId, user.KorisniciId);

            if(existingRejting != null)
            {
                existingRejting.rejting = (int)rejtingViewModel.rejting;
                existingRejting.komentar = rejtingViewModel.komentar;
                _RatingService.Update(existingRejting.RejtingId, existingRejting);
            }
            else
            {
                var rejting = new Rejting
                {
                    FilmId = rejtingViewModel.FilmId,
                    KorisniciId = user.KorisniciId,
                    Email = user.Email,
                    rejting = (int)rejtingViewModel.rejting,
                    komentar = rejtingViewModel.komentar
                };

                _RatingService.Add(rejting);
            }
            return RedirectToAction("Movies","Movies");
        }

        public IActionResult RatingAdmin()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var rejting = _RatingService.GetAll();
            return View(rejting);
        }

        public IActionResult RentalAdmin()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;


            var porudzbine = _context.Renta.Include(r => r.Korisnici).Include(r => r.Film).ToList();
            return View("RentalAdmin", porudzbine);
        }

        [HttpGet]
        public IActionResult Checkout(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var movie = _MoviesService.GetById(id);

            var rentalViewModel = new RentalViewModel
            {
                Ime = movie.Ime,
                Cena = movie.Cena,
                Email = user?.Email,
                Datum = DateTime.Now,
                FilmId = movie.FilmId
            };

            return View("Checkout", rentalViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(RentalViewModel rentalViewModel)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var rental = new Rentum
            {
                FilmId = rentalViewModel.FilmId,
                KorisniciId = user?.KorisniciId,
                Datum = rentalViewModel.Datum,
            };

            _RentalService.Add(rental);

            return RedirectToAction("Movies", "Movies");
        }

        public IActionResult UserRental()
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var userRental = _context.Renta.Include(r => r.Korisnici).Include(r => r.Film).Where(r => r.Korisnici.Email == user.Email).ToList();
            return View(userRental);
        }



        [HttpGet]
        public IActionResult ObrisiRent(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var rent = _RentalService.GetById(id);
            return View("Delete", rent);
        }


        [HttpPost]
        public IActionResult PotvrdiBrisanje(int id)
        {
            _RentalService.Delete(id);
            return RedirectToAction(nameof(RentalAdmin));
        }

        [HttpGet]
        public IActionResult ObrisiRejting(int id)
        {
            var (user, ShowDropdown) = _KorisniciService.GetUser(HttpContext);

            ViewBag.User = user;
            ViewBag.ShowDropdown = ShowDropdown;

            var rejting = _RatingService.GetById(id);
            return View("DeleteRating", rejting);
        }

        [HttpPost]
        public IActionResult PotvrdiBrisanjeRejtinga(int id)
        {

            _RatingService.Delete(id);
            return RedirectToAction(nameof(RatingAdmin));
        }
    }
}
