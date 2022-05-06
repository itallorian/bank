using BANK.BUSINESSLOGIC.Models.User;

namespace BANK.REPOSITORY.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        bool CheckUserExistence(string userName, string email);

        decimal AddUser(User user);
    }
}
