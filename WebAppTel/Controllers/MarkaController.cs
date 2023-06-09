using Microsoft.AspNetCore.Mvc;
using WebAppTel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebAppTel.Controllers
{
    public class MarkaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public MarkaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

           public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisMarka());
        }

        public IActionResult Create() 
        {
            int sljedeciId = _repozitorijUpita.MarkaSljedeciId();
            Marka marka = new Marka() { Id = sljedeciId };
            return View(marka);    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv")] Marka marka)
        {
            ModelState.Remove("Mobiteli");
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(marka);
                return RedirectToAction("Index");
            }
            return View(marka); 
        }
        [HttpGet]
        public IActionResult Update(int? id) 
        {
        if (id== null)
            {
                return NotFound();
            }
        var marka = _repozitorijUpita.DohvatiMarkuSIdom(Convert.ToInt32(id));
            if (marka==null)
            {
                return NotFound();
            }
            return View(marka);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv")] Marka marka)
        { 
        if (id != marka.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Mobiteli");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(marka);
                return RedirectToAction("Index");
            }
            return View(marka);
        }
        [HttpGet]
        public IActionResult Delete(int? id) 
        { 
        if (id == null)
            {
                return NotFound();
            }
            var marka = _repozitorijUpita.DohvatiMarkuSIdom(Convert.ToInt32(id));
            if (marka==null)
            {
                return NotFound();
            }
            return View(marka);
        }

        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var marka = _repozitorijUpita.DohvatiMarkuSIdom(Convert.ToInt32(id));
            _repozitorijUpita.Delete(marka); 
            return RedirectToAction("Index");   
        }
    }
}
