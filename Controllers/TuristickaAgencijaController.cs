using Arhitektura.IRepositories;
using Arhitektura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Arhitektura.Controllers
{
    public class TuristickaAgencijaController : Controller
    {
        private readonly ITuristickaAgencijaRepository _turistickaAgencijaRepository;

        public TuristickaAgencijaController(ITuristickaAgencijaRepository turistickaAgencijaRepository)
        {
            _turistickaAgencijaRepository = turistickaAgencijaRepository;
        }

        public IActionResult Index()
        {
            List<TuristickaAgencija> turistickeAgencije = _turistickaAgencijaRepository.GetAll();
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View(turistickeAgencije);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TuristickaAgencija turistickaAgencija)
        {
            if (ModelState.IsValid)
            {
                _turistickaAgencijaRepository.Create(turistickaAgencija);
                return RedirectToAction("Index");
            }
            return View(turistickaAgencija);
        }

        public IActionResult Edit(string id)
        {
            TuristickaAgencija turistickaAgencija = _turistickaAgencijaRepository.GetById(id);
            if (turistickaAgencija == null)
            {
                return NotFound();
            }

            return View(turistickaAgencija);
        }

        [HttpPost]
        public IActionResult Edit(string id, TuristickaAgencija turistickaAgencija)
        {
            if (id != turistickaAgencija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _turistickaAgencijaRepository.Update(id, turistickaAgencija);
                return RedirectToAction("Index");
            }

            return View(turistickaAgencija);
        }

        public IActionResult Delete(string id)
        {
            TuristickaAgencija turistickaAgencija = _turistickaAgencijaRepository.GetById(id);
            if (turistickaAgencija == null)
            {
                return NotFound();
            }

            return View(turistickaAgencija);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _turistickaAgencijaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
