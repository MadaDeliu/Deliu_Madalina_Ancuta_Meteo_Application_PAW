using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeteoApplicationMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class NewContactController : Controller
    {

        private readonly IServiceContact _serviceContact;

       


        public NewContactController(IServiceContact serviceContact)
        {
            _serviceContact = serviceContact;
        }

        public IActionResult Contact()
        {
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username");
            return View();
        }

        [HttpPost]
        public IActionResult Contact([Bind("Id,UserId,Name,Email,MessageText,Status,CreatedOn,UpdatedOn")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _serviceContact.CreateContact(contact);

                return RedirectToAction("Contact");
            }
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username");
            return View(contact);
        }
    }
}
