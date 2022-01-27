using eTickets.Data;
using eTickets.Models;
using eTickets.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.AddAsync(actor);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _actorsService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _actorsService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _actorsService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _actorsService.GetByIdAsync(id);

            if (data == null) return View("Not Found");

            await _actorsService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
