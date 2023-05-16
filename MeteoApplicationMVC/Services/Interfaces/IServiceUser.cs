using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceUser
    {
        void CreateUser(User user);
        void DeleteUser(User user);
        User GetUserById(string id);
        void UpdateUser(User user);
        List<User> GetAllUsers();
        User LoginUser(string username, string password);
        void RegisterUser(User user);
    }
}
