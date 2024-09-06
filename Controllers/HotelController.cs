using Arhitektura.IRepositories;
using Arhitektura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Arhitektura.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IDestinacijaRepository _destinacijaRepository;

        public HotelController(IHotelRepository hotelRepository, IDestinacijaRepository destinacijaRepository)
        {
            _hotelRepository = hotelRepository;
            _destinacijaRepository = destinacijaRepository;
        }

        public IActionResult Index()
        {
            List<Hotel> hoteli = _hotelRepository.GetAll();
            return View(hoteli);
        }

        public IActionResult Create()
        {
            List<Destinacija> destinacije = _destinacijaRepository.GetAll();
            ViewBag.Destinacije = destinacije;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _hotelRepository.Create(hotel);
                return RedirectToAction("Index");
            }
            ViewBag.Destinacije = _destinacijaRepository.GetAll();
            return View(hotel);
        }

        public IActionResult Edit(string id)
        {
            Hotel Hotel = _hotelRepository.GetById(id);
            if (Hotel == null)
            {
                return NotFound();
            }
            ViewBag.Destinacije = _destinacijaRepository.GetAll();
            return View(Hotel);
        }

        [HttpPost]
        public IActionResult Edit(string id, Hotel Hotel)
        {
            if (id != Hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _hotelRepository.Update(id, Hotel);
                return RedirectToAction("Index");
            }
            ViewBag.Destinacije = _destinacijaRepository.GetAll();
            return View(Hotel);
        }

        public IActionResult Delete(string id)
        {
            Hotel Hotel = _hotelRepository.GetById(id);
            if (Hotel == null)
            {
                return NotFound();
            }

            return View(Hotel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _hotelRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
