using Microsoft.AspNetCore.Mvc;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeteoApplicationMVC.Data;

namespace MeteoApplicationMVC.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IServiceContact _serviceContact;


        public ContactsController(IServiceContact serviceContact)
        {
            _serviceContact = serviceContact;
        }

        public IActionResult Index()
        {
            var contacts = _serviceContact.GetAllContacts();
            foreach(var contact in contacts)
            {
                contact.User = _serviceContact.GetUserById(contact.UserId);
            }
            return View(contacts);
        }


    public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var contacts = _serviceContact.GetContactById(id.Value);

            if (contacts == null)
            {
                return NotFound();
            }
            
            contacts.User = _serviceContact.GetUserById(contacts.UserId);
            return View(contacts);
        }

        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,UserId,Name,Email,MessageText,Status,CreatedOn,UpdatedOn")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _serviceContact.CreateContact(contact);

                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username");
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            Contact contact = _serviceContact.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username", contact.UserId);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,UserId,Name,Email,MessageText,Status,CreatedOn,UpdatedOn")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                contact.UpdatedOn = DateTime.Now;
                _serviceContact.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(_serviceContact.GetAllUsers(), "Id", "Username", contact.UserId);
            return View(contact);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _serviceContact.GetContactById(id.Value);

            if (contact == null)
            {
                return NotFound();
            }
            contact.User = _serviceContact.GetUserById(contact.UserId);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contact = _serviceContact.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            _serviceContact.DeleteContact(contact);

            return RedirectToAction("Index");
        }
    }
}
