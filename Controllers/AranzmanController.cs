using Arhitektura.IRepositories;
using Arhitektura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Arhitektura.Controllers
{
    public class AranzmanController : Controller
    {
        private readonly IAranzmanRepository _aranzmanRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ITuristickaAgencijaRepository _turistickaAgencijaRepository;

        public AranzmanController(IAranzmanRepository AranzmanRepository, IHotelRepository hotelRepository, ITuristickaAgencijaRepository turistickaAgencijaRepository)
        {
            _aranzmanRepository = AranzmanRepository;
            _hotelRepository = hotelRepository;
            _turistickaAgencijaRepository = turistickaAgencijaRepository;
        }

        public IActionResult Index()
        {
            List<Aranzman> Aranzmani = _aranzmanRepository.GetAll();
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View(Aranzmani);
        }

        public IActionResult Create()
        {
            List<Hotel> hoteli = _hotelRepository.GetAll();
            ViewBag.Hoteli = hoteli;
            List<TuristickaAgencija> turistickeAgencije = _turistickaAgencijaRepository.GetAll();
            ViewBag.TuristickeAgencije = turistickeAgencije;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Aranzman aranzman)
        {
            if (ModelState.IsValid)
            {
                _aranzmanRepository.Create(aranzman);
                return RedirectToAction("Index");
            }
            ViewBag.Hoteli = _hotelRepository.GetAll();
            ViewBag.TuristickeAgencije = _turistickaAgencijaRepository.GetAll();
            return View(aranzman);
        }

        public IActionResult Edit(string id)
        {
            Aranzman aranzman = _aranzmanRepository.GetById(id);
            if (aranzman == null)
            {
                return NotFound();
            }
            ViewBag.Hoteli = _hotelRepository.GetAll();
            ViewBag.TuristickeAgencije = _turistickaAgencijaRepository.GetAll();
            return View(aranzman);
        }

        [HttpPost]
        public IActionResult Edit(string id, Aranzman aranzman)
        {
            if (id != aranzman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _aranzmanRepository.Update(id, aranzman);
                return RedirectToAction("Index");
            }
            ViewBag.Hoteli = _hotelRepository.GetAll();
            ViewBag.TuristickeAgencije = _turistickaAgencijaRepository.GetAll();
            return View(aranzman);
        }

        public IActionResult Delete(string id)
        {
            Aranzman aranzman = _aranzmanRepository.GetById(id);
            if (aranzman == null)
            {
                return NotFound();
            }

            return View(aranzman);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _aranzmanRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Reservation(string id)
        {
            var aranzman = _aranzmanRepository.GetById(id);
            if (aranzman == null)
            {
                return NotFound();
            }
            return View(aranzman);
        }

        [HttpPost]
        public IActionResult ConfirmReservation(string id)
        {
            var aranzman = _aranzmanRepository.GetById(id);

            if (aranzman == null)
            {
                return NotFound();
            }

            aranzman.Placeno = true;

            if (ModelState.IsValid)
            {
                _aranzmanRepository.Update(id, aranzman);
            }

            return RedirectToAction("Index");
        }
    }
}
