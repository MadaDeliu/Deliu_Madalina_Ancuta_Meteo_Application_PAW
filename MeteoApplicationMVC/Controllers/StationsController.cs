using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MeteoApplicationMVC.Services;

namespace MeteoApplicationMVC.Controllers
{
    public class StationsController : Controller
    {
        private readonly IServiceStation _serviceStation;
        private readonly IServiceCity _serviceCity;
        public StationsController(IServiceStation serviceStation, IServiceCity serviceCity)
        {
            _serviceStation = serviceStation;
            _serviceCity = serviceCity;
        }

        public IActionResult Index()
        {
            List<Station> stations = _serviceStation.GetAllStations();
            foreach (var station in stations)
            {
                station.City = _serviceStation.GetCityById(station.CityId);
            }
            return View(stations);
        }

        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_serviceCity.GetAllCities(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Name,CityId,Latitude,Longitude")] Station station)
        {
            if (ModelState.IsValid)
            {
                _serviceStation.CreateStation(station);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceCity.GetAllCities(), "Id", "Name");
            return View(station);
        }

        public IActionResult Edit(int id)
        {
            Station station = _serviceStation.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            ViewBag.CityId = new SelectList(_serviceCity.GetAllCities(), "Id", "Name", station.CityId);
            return View(station);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,CityId,Latitude,Longitude")] Station station)
        {
            if (id != station.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _serviceStation.UpdateStation(station);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceCity.GetAllCities(), "Id", "Name", station.CityId);
            return View(station);
        }

        public IActionResult Details(int id)
        {
            Station station = _serviceStation.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            station.City = _serviceStation.GetCityById(station.CityId);
            return View(station);
        }

        public IActionResult Delete(int id)
        {
            Station station = _serviceStation.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            station.City = _serviceStation.GetCityById(station.CityId);
            return View(station);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Station station = _serviceStation.GetStationById(id);
            if (station == null)
            {
                return NotFound();
            }
            _serviceStation.DeleteStation(station);
            return RedirectToAction("Index");
        }
    }
}