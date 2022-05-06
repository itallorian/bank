using BANK.BUSINESSLOGIC.Models.User;
using BANK.REPOSITORY.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BANK.REPOSITORY.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User>? _users = new List<User>();
        private readonly string _dataPath = "Data/User/UsersData.json";

        public UserRepository()
        {
            using (StreamReader file = new StreamReader(_dataPath))
            {
                string json = file.ReadToEnd();

                _users = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUserExistence(string userName, string email)
        {
            try
            {
                return _users
                    .Any(u =>
                        u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase) ||
                        u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal AddUser(User user)
        {
            try
            {
                decimal id = _users.Last().Id.Value + 1;

                user.Active = true;
                user.Id = id;

                _users.Add(user);

                string data = JsonConvert.SerializeObject(_users);

                using (StreamWriter file = new StreamWriter(_dataPath))
                {
                    file.Write(data);
                }

                using (StreamReader file = new StreamReader(_dataPath))
                {
                    string json = file.ReadToEnd();

                    _users = JsonConvert.DeserializeObject<List<User>>(json);
                }

                user = _users.Where(u =>
                                u.UserName.Equals(user.UserName, StringComparison.InvariantCultureIgnoreCase) ||
                                u.Email.Equals(user.Email, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

                return user.Id ?? 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
