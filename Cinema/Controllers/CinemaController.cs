using Cinema.Models;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        private static List<Sale> saleList = new()
        {
            new Sale() {Id = Guid.NewGuid(), Nome= "SALA NORD" },
            new Sale() {Id = Guid.NewGuid(), Nome= "SALA SUD" },
            new Sale() {Id = Guid.NewGuid(), Nome= "SALA EST" },
        };

        private static List<BigliettoBase> Utente = new List<BigliettoBase>()
        {
            new BigliettoBase() {
                Id= Guid.NewGuid(),
                Nome="Ninfa",
                Cognome= "Carreno",
                IsRidotto=true,
                Sale=saleList[0]},
        };


        public IActionResult Index()
        {
            var UserList = new BigliettoViewModel()
            {
                Ticket = Utente
            };

            return View(UserList);
        }


        public IActionResult Add()
        {
            var model = new AddTicket
            {
                StanzeList = saleList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddTicket item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            var ticket = new BigliettoBase()
            {
                Id = Guid.NewGuid(),
                Nome = item.Nome,
                Cognome = item.Cognome,
                IsRidotto = item.IsRidotto,
                Sale = saleList.FirstOrDefault(x => x.Id == item.SaleID),
            };

            Utente.Add(ticket);

            return RedirectToAction("Index");
        }

    }

}

