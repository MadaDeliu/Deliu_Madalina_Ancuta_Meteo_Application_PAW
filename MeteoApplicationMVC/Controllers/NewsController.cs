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
    public class NewsController : Controller
    {
        private readonly IServiceNews _serviceSevereWeatherEvent;

        public NewsController(IServiceNews serviceSevereWeatherEvent)
        {
            _serviceSevereWeatherEvent = serviceSevereWeatherEvent;
        }

        public IActionResult Index()
        {
            List<News> severeWeatherEvents = _serviceSevereWeatherEvent.GetAllSevereWeatherEvents();
            foreach (var severeWeatherEvent in severeWeatherEvents)
            {
                severeWeatherEvent.City = _serviceSevereWeatherEvent.GetCityById(severeWeatherEvent.CityId);
            }
            return View(severeWeatherEvents);
        }

        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Type,CityId,Severity,Code,Date")] News severeWeatherEvent)
        {
            if (ModelState.IsValid)
            {
                _serviceSevereWeatherEvent.CreateNews(severeWeatherEvent);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name");
            return View(severeWeatherEvent);
        }

        public IActionResult Edit(int id)
        {
            News severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name", severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Type,CityId,Severity,Code,Date")] News severeWeatherEvent)
        {
            if (id != severeWeatherEvent.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _serviceSevereWeatherEvent.UpdateSevereWeatherEvents(severeWeatherEvent);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name", severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        public IActionResult Details(int id)
        {
            News severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            severeWeatherEvent.City = _serviceSevereWeatherEvent.GetCityById(severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        public IActionResult Delete(int id)
        {
            News severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            severeWeatherEvent.City = _serviceSevereWeatherEvent.GetCityById(severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            News severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            _serviceSevereWeatherEvent.DeleteNews(severeWeatherEvent);
            return RedirectToAction("Index");
        }
    }
}
