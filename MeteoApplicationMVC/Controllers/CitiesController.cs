using Microsoft.AspNetCore.Mvc;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;

namespace MeteoApplicationMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IServiceCity _serviceCity;

        public CitiesController(IServiceCity serviceCity)
        {
            _serviceCity = serviceCity;
        }

        public IActionResult Index()
        {
            var cities = _serviceCity.GetAllCities();

            return View(cities);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _serviceCity.GetCityById(id.Value);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _serviceCity.CreateCity(city);

                return RedirectToAction("Index");
            }

            return View(city);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _serviceCity.GetCityById(id.Value);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _serviceCity.UpdateCity(city);

                return RedirectToAction("Index");
            }

            return View(city);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _serviceCity.GetCityById(id.Value);

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var city = _serviceCity.GetCityById(id);

            if (city == null)
            {
                return NotFound();
            }

            _serviceCity.DeleteCity(city);

            return RedirectToAction("Index");
        }
    }
}
