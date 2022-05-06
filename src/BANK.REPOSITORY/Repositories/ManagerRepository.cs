using BANK.BUSINESSLOGIC.Models.Manager;
using BANK.REPOSITORY.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BANK.REPOSITORY.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private List<Manager>? _managers = new List<Manager>();

        public ManagerRepository()
        {
            using (StreamReader file = new StreamReader("Data/Manager/AdministratorsData.json"))
            {
                string json = file.ReadToEnd();

                _managers = JsonConvert.DeserializeObject<List<Manager>>(json);
            }
        }

        public Manager? GetManager(string username, string password)
        {
            Manager? manager =
                (
                    from m in _managers

                    where
                        m.UserName.Equals(username)
                        && m.Password.Equals(password)
                    select
                        m
                ).FirstOrDefault();

            return manager;
        }
    }
}
