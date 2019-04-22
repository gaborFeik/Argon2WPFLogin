using Argon2LoginWPF.Database;
using Argon2LoginWPF.Models;
using System.Collections.Generic;
using System.Linq;

namespace Argon2LoginWPF.Repository
{
    public class UserRepository
    {
        /// <summary>
        /// Repository method to get current users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            using (UserDbContext db = new UserDbContext())
            {
                return db.Users.ToList();
            }

        }
    }
}
