using System.Linq;
using Argon2LoginWPF.Hashing;
using Argon2LoginWPF.Models;
using Argon2LoginWPF.Repository;

namespace Argon2LoginWPF.ViewModels
{
    public class AccountControlView
    {
        /// <summary>
        /// Private field to store the repository
        /// </summary>
        private UserRepository _Repository;

        /// <summary>
        /// Internal property to get repository or set to a new instance
        /// </summary>
        internal UserRepository Repository
        {
            get
            {
                return _Repository ?? (_Repository = new UserRepository());
            }
            set
            {
                _Repository = value;
            }
        }

        /// <summary>
        /// Public method to check whether accountname exists 
        /// </summary>
        /// <param name="account"></param>
        /// <returns>true if exist, false otherwise</returns>
        public User GotUser(Account account)
        {
            return Repository.GetUsers().FirstOrDefault(r => r.Name == account.Name);
        }

        /// <summary>
        /// Method to convert Account to user with a salted password
        /// </summary>
        /// <param name="account"></param>
        /// <returns> returns user with Name,SaltedPwHash and Salt property</returns>
        public User UserPwToHash(Account account)
        {
            using (var pwHash = new Hashing.HashingPassword())
            {
                return pwHash.RegisterHash(account);
            }
        }

        /// <summary>
        /// Public method calls GotUser method and call to save it in the database.
        /// </summary>
        /// <param name="account"></param>
        /// <returns>Return progress message whether if it's succesful or registered</returns>
        public Account Register(Account account)
        {
            if (GotUser(account) == null)
            {
                var newUser = UserPwToHash(account);
                using (var register = new Registration())
                {
                    register.RegisterUser(newUser);
                }
                account.ValidationMessage = "Account creation was succesful";
                return account;

            }
            account.ValidationMessage = "Username is already registered";
            return account;
        }

        /// <summary>
        /// Public method gets the user with GotUser calls LoginPwCheck and returns the results
        /// </summary>
        /// <param name="account"></param>
        /// <returns>Returns account in every cases, ValidationMessage determs login status</returns>
        public Account Login(Account account)
        {
            var user = GotUser(account);
            if (user != null)
            {
                if (LoginPwCheck(account))
                {
                    account.ValidationMessage = $"Login was succesful, welcome {account.Name}";
                    return account;
                }
                account.ValidationMessage = "Login failed";
                return account;
            }
            else
            {
                account.ValidationMessage = "Incorrect username or password";

                return account;
            }
        }

        /// <summary>
        /// private method generating PwHash from user salt
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private bool LoginPwCheck(Account account)
        {
            var user = GotUser(account);
            using (var pwHash = new HashingPassword())
            {
                pwHash.salt = CustomCoder.StringToByteArray(user.Salt);
                var ExistUser = pwHash.LoginHash(account);
                return (ExistUser.SaltedPwHash == user.SaltedPwHash) ? true : false;
            }

        }

    }
}
