using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceContact : IServiceContact
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceContact(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateContact(Contact contact)
        {
            _repositoryWrapper.RepositoryContact.Create(contact);
            _repositoryWrapper.Save();
        }

        public void DeleteContact(Contact contact)
        {
            _repositoryWrapper.RepositoryContact.Delete(contact);
            _repositoryWrapper.Save();
        }

        public Contact GetContactById(int id)
        {
            Contact contact = _repositoryWrapper.RepositoryContact.FindByCondition(c => c.Id == id).FirstOrDefault();
            return contact;
        }

        public void UpdateContact(Contact contact)
        {
            _repositoryWrapper.RepositoryContact.Update(contact);
            _repositoryWrapper.Save();
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = _repositoryWrapper.RepositoryContact.FindAll().ToList();
            return contacts;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = _repositoryWrapper.RepositoryUser.FindAll().ToList();
            return users;
        }

        public User GetUserById(string? id)
        {
            if (id == null)
            {
                return null;
            }
            return _repositoryWrapper.RepositoryUser.FindByCondition(r => r.Id == id).FirstOrDefault();
        }

    }
}

