using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppTel.Models;

namespace WebAppTel.Controllers
{
    public class MobitelController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public MobitelController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }


        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisMobitel());
        }
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_repozitorijUpita.PopisMarka(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Mobitel mobitel = new Mobitel() { Id = sljedeciId };
            return View(mobitel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,GodinaProizvodnje,Cijena,SlikaUrl,MarkaId")] Mobitel mobitel)
        {
            ModelState.Remove("Marka");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(mobitel);
                return RedirectToAction("Index");
            }
            ViewData["MarkaId"] = new SelectList(_repozitorijUpita.PopisMarka(), "Id", "Naziv", mobitel.MarkaId);
            return View(mobitel);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Mobitel mobitel = _repozitorijUpita.DohvatiMobitelSIdom(id);

            if (mobitel == null) { return NotFound(); }

            ViewData["MarkaId"] = new SelectList(_repozitorijUpita.PopisMarka(), "Id", "Naziv", mobitel.MarkaId);
            return View(mobitel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")] Mobitel mobitel)
        {
            if (id != mobitel.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Marka");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(mobitel);
                return RedirectToAction("Index");
            }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisMarka(), "Id", "Naziv", mobitel.MarkaId);
            return View(mobitel);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var mobitel = _repozitorijUpita.DohvatiMobitelSIdom(Convert.ToInt16(id));

            if (mobitel == null)
            {
                return NotFound();
            }

            return View(mobitel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var mobitel = _repozitorijUpita.DohvatiMobitelSIdom(id);
            _repozitorijUpita.Delete(mobitel);
            return RedirectToAction("Index");

        }


        public ActionResult SearchIndex(string mobitelModel, string searchString)
        {
            var Model = new List<string>();

            var modelUpit = _repozitorijUpita.PopisMarka();

            ViewData["mobitelModel"] = new SelectList(_repozitorijUpita.PopisMarka(), "Naziv", "Naziv", modelUpit);

            var mobitels = _repozitorijUpita.PopisMobitel();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                mobitels = mobitels.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(mobitelModel))
                return View(mobitels);
            else
            {
                return View(mobitels.Where(x => x.Marka.Naziv == mobitelModel));
            }
        }
    }
}
