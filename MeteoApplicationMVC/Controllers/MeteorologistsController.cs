using Microsoft.AspNetCore.Mvc;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;
using MeteoApplicationMVC.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeteoApplicationMVC.Controllers
{
    public class MeteorologistsController : Controller
    {
        private readonly IServiceMeteorologist _serviceMeteorologist;

        public MeteorologistsController(IServiceMeteorologist serviceMeteorologist)
        {
            _serviceMeteorologist = serviceMeteorologist;
        }

        public IActionResult Index()
        {
            var meteorologists = _serviceMeteorologist.GetAllMeteorologists();
            foreach (var meteorologist in meteorologists)
            {
                meteorologist.Station = _serviceMeteorologist.GetStationById(meteorologist.StationId);
            }
            return View(meteorologists);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologist = _serviceMeteorologist.GetMeteorologistById(id.Value);

            if (meteorologist == null)
            {
                return NotFound();
            }
            meteorologist.Station = _serviceMeteorologist.GetStationById(meteorologist.StationId);
            return View(meteorologist);
        }

        public IActionResult Create()
        {
            ViewBag.StationId = new SelectList(_serviceMeteorologist.GetAllStations(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,StationId,Name,Experience")] Meteorologist meteorologist)
        {
            if (ModelState.IsValid)
            {
                _serviceMeteorologist.CreateMeteorologist(meteorologist);

                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(_serviceMeteorologist.GetAllStations(), "Id", "Name");
            return View(meteorologist);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologist = _serviceMeteorologist.GetMeteorologistById(id.Value);

            if (meteorologist == null)
            {
                return NotFound();
            }
            ViewBag.StationId = new SelectList(_serviceMeteorologist.GetAllStations(), "Id", "Name", meteorologist.StationId);
            return View(meteorologist);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,StationId,Name,Experience")] Meteorologist meteorologist)
        {
            if (id != meteorologist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _serviceMeteorologist.UpdateMeteorologist(meteorologist);

                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(_serviceMeteorologist.GetAllStations(), "Id", "Name", meteorologist.StationId);
            return View(meteorologist);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologist = _serviceMeteorologist.GetMeteorologistById(id.Value);

            if (meteorologist == null)
            {
                return NotFound();
            }
            meteorologist.Station = _serviceMeteorologist.GetStationById(meteorologist.StationId);
            return View(meteorologist);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var meteorologist = _serviceMeteorologist.GetMeteorologistById(id);

            if (meteorologist == null)
            {
                return NotFound();
            }

            _serviceMeteorologist.DeleteMeteorologist(meteorologist);

            return RedirectToAction("Index");
        }
    }
}
