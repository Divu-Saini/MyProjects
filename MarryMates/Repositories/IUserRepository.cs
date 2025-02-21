using MarryMatesDotNet.Models;

namespace MarryMatesDotNet.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserByEmail(string email);

        IEnumerable<User> GetClients();
        IEnumerable<User> GetVendors();
        

    }
}
