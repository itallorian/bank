using BANK.BUSINESSLOGIC.Models.Customer;
using BANK.REPOSITORY.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BANK.REPOSITORY.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();
        private readonly string _dataPath = "Data/Customer/CustomersData.json";

        public CustomerRepository()
        {
            using (StreamReader file = new StreamReader(_dataPath))
            {
                string json = file.ReadToEnd();

                _customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }

        public List<Customer> GetCustomersToApprove()
        {
            try
            {
                return (from customer in _customers
                        where customer.Okay == false
                        select customer).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Customer> GetUserCustomers(decimal userId)
        {
            try
            {
                return (from customer in _customers
                        where customer.UserApproval == userId
                        select customer).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ApproveUser(decimal customerId, decimal userId)
        {
            var result = (from customer in _customers
                          where customer.Id == customerId
                          select customer).FirstOrDefault();

            _customers.Remove(result);

            result.UserApproval = userId;
            result.Okay = true;

            _customers.Add(result);

            _customers = _customers.OrderBy(c => c.Id).ToList();

            string data = JsonConvert.SerializeObject(_customers);

            using (StreamWriter file = new StreamWriter(_dataPath))
            {
                file.Write(data);
            }
        }
    }
}
