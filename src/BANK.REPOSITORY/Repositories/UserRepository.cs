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

        public bool CheckUserExistence(string userName, string email, decimal? userId = null)
        {
            try
            {
                return (from user in _users
                        where
                            (user.UserName.Equals(userName) || user.Email.Equals(email))
                            &&
                            (
                                (
                                    userId != null && userId > 0
                                    && user.Id != userId
                                )
                                || userId == null
                            )

                        select user).Any();
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

        public User GetUser(decimal id)
        {
            try
            {
                return _users.Where(u => u.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal EditUser(User user)
        {
            try
            {
                User userData = GetUser(user.Id.Value);

                if (string.IsNullOrEmpty(user.Password) == true)
                {
                    user.Password = userData.Password;
                }

                _users.Remove(userData);

                _users.Add(user);

                _users = _users.OrderBy(u => u.Id).ToList();

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

                user = _users.Where(u => u.Id == user.Id).FirstOrDefault();

                return user.Id ?? 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
