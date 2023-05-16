using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MeteoApplicationMVC.Services;

namespace MeteoApplicationMVC.Controllers
{
    public class FavoriteLocationsController : Controller
    {
        private readonly IServiceFavoriteLocation _serviceFavoriteLocation;

        public FavoriteLocationsController(IServiceFavoriteLocation serviceFavoriteLocations)
        {
            _serviceFavoriteLocation = serviceFavoriteLocations;
        }

        public IActionResult Index()
        {
            List<FavoriteLocation> favoriteLocations = _serviceFavoriteLocation.GetAllFavoriteLocations();
            foreach (FavoriteLocation favoriteLocation in favoriteLocations)
            {
                favoriteLocation.City = _serviceFavoriteLocation.GetCityById(favoriteLocation.CityId);
                favoriteLocation.User = _serviceFavoriteLocation.GetUserById(favoriteLocation.UserId);
            }
            return View(favoriteLocations);
        }

        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_serviceFavoriteLocation.GetAllCities(), "Id", "Name");
            ViewBag.UserId = new SelectList(_serviceFavoriteLocation.GetAllUsers(), "Id", "Username");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,UserId,CityId,CreatedAt,UpdatedAt")] FavoriteLocation favoriteLocation)
        {
            if (ModelState.IsValid)
            {
                favoriteLocation.CreatedAt = DateTime.Now;
                _serviceFavoriteLocation.CreateFavoriteLocation(favoriteLocation);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceFavoriteLocation.GetAllCities(), "Id", "Name");
            ViewBag.UserId = new SelectList(_serviceFavoriteLocation.GetAllUsers(), "Id", "Username");
            return View(favoriteLocation);
        }

        public IActionResult Edit(int id)
        {
            FavoriteLocation favoriteLocation = _serviceFavoriteLocation.GetFavoriteLocationById(id);
            if (favoriteLocation == null)
            {
                return NotFound();
            }
            ViewBag.CityId = new SelectList(_serviceFavoriteLocation.GetAllCities(), "Id", "Name", favoriteLocation.CityId);
            ViewBag.UserId = new SelectList(_serviceFavoriteLocation.GetAllUsers(), "Id", "Username", favoriteLocation.UserId);
            return View(favoriteLocation);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,UserId,CityId,CreatedAt,UpdatedAt")] FavoriteLocation favoriteLocation)
        {
            if (id != favoriteLocation.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                favoriteLocation.UpdatedAt = DateTime.Now;
                _serviceFavoriteLocation.UpdateFavoriteLocation(favoriteLocation);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceFavoriteLocation.GetAllCities(), "Id", "Name", favoriteLocation.CityId);
            ViewBag.UserId = new SelectList(_serviceFavoriteLocation.GetAllUsers(), "Id", "Username", favoriteLocation.UserId);
            return View(favoriteLocation);
        }

        public IActionResult Details(int id)
        {
            FavoriteLocation favoriteLocation = _serviceFavoriteLocation.GetFavoriteLocationById(id);
            if (favoriteLocation == null)
            {
                return NotFound();
            }
            favoriteLocation.City = _serviceFavoriteLocation.GetCityById(favoriteLocation.CityId);
            favoriteLocation.User = _serviceFavoriteLocation.GetUserById(favoriteLocation.UserId);
            return View(favoriteLocation);
        }

        public IActionResult Delete(int id)
        {
            FavoriteLocation favoriteLocation = _serviceFavoriteLocation.GetFavoriteLocationById(id);
            if (favoriteLocation == null)
            {
                return NotFound();
            }
            favoriteLocation.City = _serviceFavoriteLocation.GetCityById(favoriteLocation.CityId);
            favoriteLocation.User = _serviceFavoriteLocation.GetUserById(favoriteLocation.UserId);
            return View(favoriteLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            FavoriteLocation favoriteLocation = _serviceFavoriteLocation.GetFavoriteLocationById(id);
            if (favoriteLocation == null)
            {
                return NotFound();
            }
            _serviceFavoriteLocation.DeleteFavoriteLocation(favoriteLocation);
            return RedirectToAction("Index");
        }
    }
}
