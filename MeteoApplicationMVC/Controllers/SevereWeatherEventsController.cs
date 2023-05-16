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
    public class SevereWeatherEventsController : Controller
    {
        private readonly IServiceSevereWeatherEvents _serviceSevereWeatherEvent;

        public SevereWeatherEventsController(IServiceSevereWeatherEvents serviceSevereWeatherEvent)
        {
            _serviceSevereWeatherEvent = serviceSevereWeatherEvent;
        }

        public IActionResult Index()
        {
            List<SevereWeatherEvent> severeWeatherEvents = _serviceSevereWeatherEvent.GetAllSevereWeatherEvents();
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
        public IActionResult Create([Bind("Id,Type,CityId,Severity,Code,Date")] SevereWeatherEvent severeWeatherEvent)
        {
            if (ModelState.IsValid)
            {
                _serviceSevereWeatherEvent.CreateSevereWeatherEvents(severeWeatherEvent);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name");
            return View(severeWeatherEvent);
        }

        public IActionResult Edit(int id)
        {
            SevereWeatherEvent severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            ViewBag.CityId = new SelectList(_serviceSevereWeatherEvent.GetAllCities(), "Id", "Name", severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Type,CityId,Severity,Code,Date")] SevereWeatherEvent severeWeatherEvent)
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
            SevereWeatherEvent severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            severeWeatherEvent.City = _serviceSevereWeatherEvent.GetCityById(severeWeatherEvent.CityId);
            return View(severeWeatherEvent);
        }

        public IActionResult Delete(int id)
        {
            SevereWeatherEvent severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
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
            SevereWeatherEvent severeWeatherEvent = _serviceSevereWeatherEvent.GetSevereWeatherEventsById(id);
            if (severeWeatherEvent == null)
            {
                return NotFound();
            }
            _serviceSevereWeatherEvent.DeleteSevereWeatherEvents(severeWeatherEvent);
            return RedirectToAction("Index");
        }
    }
}
