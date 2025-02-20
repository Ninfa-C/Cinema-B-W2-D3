using Cinema.Models;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Sale> saleList = new()
        {
            new Sale()
            {
                Id = Guid.NewGuid(),
                Nome= "SALA NORD",
                FilmInProgrammazione = new List<Movie>
                {
                    new Movie() { Titolo = "Harry Potter", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "Il signore degli anelli", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "Star wars", Id= Guid.NewGuid(), Posti=2}
                }
            },
            new Sale()
            {
                Id = Guid.NewGuid(),
                Nome= "SALA SUD",
                FilmInProgrammazione = new List<Movie>
                {
                    new Movie() { Titolo = "The grudge", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "The Ring", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "It", Id= Guid.NewGuid(), Posti=2}
                }
            },
            new Sale()
            {
                Id = Guid.NewGuid(),
                Nome= "SALA EST",
                FilmInProgrammazione = new List<Movie>
                {
                    new Movie() { Titolo = "Come d'incanto", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "Mulan", Id= Guid.NewGuid(), Posti=2},
                    new Movie() { Titolo = "La sirenetta", Id= Guid.NewGuid(), Posti=2}
                }
            },
        };

        private static readonly List<BigliettoBase> Utente =
        [
            new BigliettoBase() {
                Id= Guid.NewGuid(),
                Nome="Ninfa",
                Cognome= "Carreno",
                IsRidotto=true,
                Film= saleList[0].FilmInProgrammazione[2],
                Sale=saleList[0]},
        ];


        public IActionResult Index()
        {
            var UserList = new BigliettoViewModel()
            {
                Ticket = Utente
            };

            return View(UserList);
        }



        public IActionResult Add(Guid? SalaScelta)
        {
            var selectedSala = saleList.FirstOrDefault(s => s.Id == SalaScelta);

            var model = new AddTicket
            {
                StanzeList = saleList,
                MovieList = selectedSala != null ? selectedSala.FilmInProgrammazione.ToList() : new List<Movie>(),
                SaleID = SalaScelta
            };

            return View(model);
        }



        [HttpPost]
        public IActionResult AddSave(AddTicket item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            var selectedSala = saleList.FirstOrDefault(x => x.Id == item.SaleID);
            var selectedMovie = selectedSala?.FilmInProgrammazione.FirstOrDefault(f => f.Id == item.MovieID);

            if (selectedSala == null || selectedMovie == null)
            {
                TempData["Error"] = "Sala o Film selezionato non valido!";
                return RedirectToAction("Add");
            }
            int contabiglietti = Utente.Count(x => x.Film?.Id == item.MovieID);

            if (contabiglietti >= selectedMovie?.Posti)
            {
                TempData["Error"] = "La sala selezionata è piena!";
                return RedirectToAction("Add");
            }
            var ticket = new BigliettoBase()
            {
                Id = Guid.NewGuid(),
                Nome = item.Nome,
                Cognome = item.Cognome,
                IsRidotto = item.IsRidotto,
                Sale = selectedSala,
                Film = selectedMovie,
            };

            Utente.Add(ticket);

            return RedirectToAction("Index");
        }

    }

}

