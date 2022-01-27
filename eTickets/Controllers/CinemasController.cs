using eTickets.Data;
using eTickets.Models;
using eTickets.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _cinemasService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _cinemasService.AddAsync(cinema);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _cinemasService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _cinemasService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            if (id == cinema.Id)
            {
                await _cinemasService.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }

            return View(cinema);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _cinemasService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _cinemasService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            await _cinemasService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
