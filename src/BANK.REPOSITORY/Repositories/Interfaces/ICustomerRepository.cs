using BANK.BUSINESSLOGIC.Models.Customer;

namespace BANK.REPOSITORY.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomersToApprove();

        List<Customer> GetUserCustomers(decimal userId);

        void ApproveUser(decimal customerId, decimal userId);
    }
}
