using Argon2LoginWPF.Database;
using Argon2LoginWPF.Models;
using System;


namespace Argon2LoginWPF.Repository
{
   public class Registration: IDisposable
    {
        /// <summary>
        /// Dispose class after using
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// public method for new user registration in DB
        /// </summary>
        /// <param name="user"></param>
        public void RegisterUser(User user)
        {
            using (var db = new UserDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
