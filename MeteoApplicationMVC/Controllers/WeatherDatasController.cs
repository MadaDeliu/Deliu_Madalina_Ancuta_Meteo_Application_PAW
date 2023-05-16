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
    public class WeatherDatasController : Controller
    {
        private readonly IServiceWeatherData _serviceWeatherData;
        public WeatherDatasController(IServiceWeatherData serviceWeatherData)
        {
            _serviceWeatherData = serviceWeatherData;
        }

        public IActionResult Index()
        {
            List<WeatherData> weatherDataList = _serviceWeatherData.GetAllWeatherDatas();
            foreach (var weatherData in weatherDataList)
            {
                weatherData.Station = _serviceWeatherData.GetStationById(weatherData.StationId);
            }
            return View(weatherDataList);
        }

        public IActionResult Create()
        {
            ViewBag.StationId = new SelectList(_serviceWeatherData.GetAllStations(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,StationId,Datetime,Temperature,WindSpeed,Precipitation,Humidity")] WeatherData weatherData)
        {
            if (ModelState.IsValid)
            {
                _serviceWeatherData.CreateWeatherData(weatherData);
                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(_serviceWeatherData.GetAllStations(), "Id", "Name");
            return View(weatherData);
        }

        public IActionResult Edit(int id)
        {
            WeatherData weatherData = _serviceWeatherData.GetWeatherDataById(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            ViewBag.StationId = new SelectList(_serviceWeatherData.GetAllStations(), "Id", "Name", weatherData.StationId);
            return View(weatherData);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,StationId,Datetime,Temperature,WindSpeed,Precipitation,Humidity")] WeatherData weatherData)
        {
            if (id != weatherData.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _serviceWeatherData.UpdateWeatherData(weatherData);
                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(_serviceWeatherData.GetAllStations(), "Id", "Name", weatherData.StationId);
            return View(weatherData);
        }

        public IActionResult Details(int id)
        {
            WeatherData weatherData = _serviceWeatherData.GetWeatherDataById(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            weatherData.Station = _serviceWeatherData.GetStationById(weatherData.StationId);
            return View(weatherData);
        }

        public IActionResult Delete(int id)
        {
            WeatherData weatherData = _serviceWeatherData.GetWeatherDataById(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            weatherData.Station = _serviceWeatherData.GetStationById(weatherData.StationId);
            return View(weatherData);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            WeatherData weatherData = _serviceWeatherData.GetWeatherDataById(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            _serviceWeatherData.DeleteWeatherData(weatherData);
            
            return RedirectToAction("Index");
        }
    }
}