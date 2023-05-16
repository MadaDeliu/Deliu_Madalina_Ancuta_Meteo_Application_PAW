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
    public class AlertsController : Controller
    {
        private readonly IServiceAlert _serviceAlert;

        public AlertsController(IServiceAlert serviceAlert)
        {
            _serviceAlert = serviceAlert;
        }

        public IActionResult Index()
        {
            List<Alert> alerts = _serviceAlert.GetAllAlerts();
            foreach (var alert in alerts)
            {
                alert.City = _serviceAlert.GetCityById(alert.CityId);
                alert.User = _serviceAlert.GetUserById(alert.UserId);
            }
            return View(alerts);
        }

        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_serviceAlert.GetAllCities(), "Id", "Name");
            ViewBag.UserId = new SelectList(_serviceAlert.GetAllUsers(), "Id", "Username");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,CityId,UserId,Type,ThresholdValue,CreatedAt,UpdatedAt")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                alert.CreatedAt = DateTime.Now;
                _serviceAlert.CreateAlert(alert);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceAlert.GetAllCities(), "Id", "Name");
            ViewBag.UserId = new SelectList(_serviceAlert.GetAllUsers(), "Id", "Username");
            return View(alert);
        }

        public IActionResult Edit(int id)
        {
            Alert alert = _serviceAlert.GetAlertById(id);
            if (alert == null)
            {
                return NotFound();
            }
            ViewBag.CityId = new SelectList(_serviceAlert.GetAllCities(), "Id", "Name", alert.CityId);
            ViewBag.UserId = new SelectList(_serviceAlert.GetAllUsers(), "Id", "Username", alert.UserId);
            return View(alert);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,CityId,UserId,Type,ThresholdValue,CreatedAt,UpdatedAt")] Alert alert)
        {
            if (id != alert.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                alert.UpdatedAt = DateTime.Now;
                _serviceAlert.UpdateAlert(alert);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(_serviceAlert.GetAllCities(), "Id", "Name", alert.CityId);
            ViewBag.UserId = new SelectList(_serviceAlert.GetAllUsers(), "Id", "Username", alert.UserId);
            return View(alert);
        }

        public IActionResult Details(int id)
        {
            Alert alert = _serviceAlert.GetAlertById(id);
            if (alert == null)
            {
                return NotFound();
            }
            alert.City = _serviceAlert.GetCityById(alert.CityId);
            alert.User = _serviceAlert.GetUserById(alert.UserId);
            return View(alert);
        }

        public IActionResult Delete(int id)
        {
            Alert alert = _serviceAlert.GetAlertById(id);
            if (alert == null)
            {
                return NotFound();
            }
            alert.City = _serviceAlert.GetCityById(alert.CityId);
            alert.User = _serviceAlert.GetUserById(alert.UserId);
            return View(alert);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Alert alert = _serviceAlert.GetAlertById(id);
            if (alert == null)
            {
                return NotFound();
            }
            _serviceAlert.DeleteAlert(alert);
            return RedirectToAction("Index");
        }
    }
}
