using MeteoApplicationMVC.Models;
using System.Diagnostics.Contracts;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceContact
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact GetContactById(int id);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        List<User> GetAllUsers();
        User GetUserById(string? id);
    }
}
