using BANK.BUSINESSLOGIC.Models.User;

namespace BANK.REPOSITORY.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        bool CheckUserExistence(string userName, string email, decimal? id = null);

        decimal AddUser(User user);

        User GetUser(decimal id);

        decimal EditUser(User user);

        User GetUser(string userName, string password);
    }
}
