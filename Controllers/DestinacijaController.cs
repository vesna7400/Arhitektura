using Arhitektura.IRepositories;
using Arhitektura.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Arhitektura.Controllers
{
    public class DestinacijaController : Controller
    {
        private readonly IDestinacijaRepository _destinacijaRepository;

        public DestinacijaController(IDestinacijaRepository destinacijaRepository)
        {
            _destinacijaRepository = destinacijaRepository;
        }

        public IActionResult Index()
        {
            List<Destinacija> destinacije = _destinacijaRepository.GetAll();
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View(destinacije);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Destinacija destinacija)
        {
            if (ModelState.IsValid)
            {
                _destinacijaRepository.Create(destinacija);
                return RedirectToAction("Index");
            }
            return View(destinacija);
        }

        public IActionResult Edit(string id)
        {
            Destinacija destinacija = _destinacijaRepository.GetById(id);
            if (destinacija == null)
            {
                return NotFound();
            }

            return View(destinacija);
        }

        [HttpPost]
        public IActionResult Edit(string id, Destinacija destinacija)
        {
            if (id != destinacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _destinacijaRepository.Update(id, destinacija);
                return RedirectToAction("Index");
            }

            return View(destinacija);
        }

        public IActionResult Delete(string id)
        {
            Destinacija destinacija = _destinacijaRepository.GetById(id);
            if (destinacija == null)
            {
                return NotFound();
            }

            return View(destinacija);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            _destinacijaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
