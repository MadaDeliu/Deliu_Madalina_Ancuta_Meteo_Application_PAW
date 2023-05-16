using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;


namespace MeteoApplicationMVC.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ServiceUser(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateUser(User user)
        {
            _repositoryWrapper.RepositoryUser.Create(user);
            _repositoryWrapper.Save();
        }

        public void DeleteUser(User user)
        {
            _repositoryWrapper.RepositoryUser.Delete(user);
            _repositoryWrapper.Save();
        }

        public User GetUserById(string id)
        {
            User user = _repositoryWrapper.RepositoryUser.FindByCondition(u => u.Id == id).First();
            return user;
        }

        public void UpdateUser(User user)
        {
            _repositoryWrapper.RepositoryUser.Update(user);
            _repositoryWrapper.Save();
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _repositoryWrapper.RepositoryUser.FindAll().ToList();
            return users;
        }

        public User LoginUser(string email, string password)
        {         
            User user = _repositoryWrapper.RepositoryUser.FindByCondition(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user;
        }

        public void RegisterUser(User user)
        {
            _repositoryWrapper.RepositoryUser.Create(user);
            _repositoryWrapper.Save();
        }
    }
}
