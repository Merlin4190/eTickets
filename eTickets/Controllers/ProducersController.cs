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
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _producersService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _producersService.AddAsync(producer);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _producersService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _producersService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if(id == producer.Id)
            {
                await _producersService.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _producersService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _producersService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            await _producersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
