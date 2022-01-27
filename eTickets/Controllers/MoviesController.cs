using eTickets.Data;
using eTickets.Data.ViewModels;
using eTickets.Models;
using eTickets.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _moviesService.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _moviesService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var searchResult = data.Where(m => m.Name.Contains(searchString) || m.Description.Contains(searchString)).ToList();
                return View("Index", searchResult);
            }
            return View("Index", data);
        }

        public async Task<IActionResult> Create()
        {
            var dropDownsData = await _moviesService.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(dropDownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(dropDownsData.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(dropDownsData.Producers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var dropDownsData = await _moviesService.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(dropDownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(dropDownsData.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(dropDownsData.Producers, "Id", "FullName");

                return View(movie);
            }

            await _moviesService.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _moviesService.GetMovieByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _moviesService.GetMovieByIdAsync(id);

            if (data == null) return View("Not Found");

            var response = new UpdateMovieVM()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                MovieCategory = data.MovieCategory,
                ImageURL = data.ImageURL,
                Price = data.Price,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ProducerId = data.ProducerId,
                CinemaId = data.CinemaId,
                ActorIds = data.ActorMovies.Select(a => a.ActorId).ToList()
            };

            var dropDownsData = await _moviesService.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(dropDownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(dropDownsData.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(dropDownsData.Producers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateMovieVM movie)
        {

            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            if (id == movie.Id)
            {
                await _moviesService.UpdateMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }

            return View("Not Found");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _moviesService.GetMovieByIdAsync(id);

            if (data == null) return View("Not Found");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _moviesService.GetMovieByIdAsync(id);

            if (data == null) return View("Not Found");

            await _moviesService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
