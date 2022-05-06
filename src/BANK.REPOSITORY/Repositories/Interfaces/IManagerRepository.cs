using BANK.BUSINESSLOGIC.Models.Manager;

namespace BANK.REPOSITORY.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Manager? GetManager(string username, string password);
    }
}
