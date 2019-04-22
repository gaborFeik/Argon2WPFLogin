using Argon2LoginWPF.Models;

namespace Argon2LoginWPF.ViewModels
{
   public class AccountCreation
    {
        /// <summary>
        /// Model property
        /// </summary>
        public Account NewAccount { get; set; }

        /// <summary>
        /// Constractor setting a new instance of the model
        /// </summary>
        public AccountCreation()
        {
            NewAccount = new Account();
        }

        /// <summary>
        /// Model method for registering
        /// </summary>
        public void ValidateUser()
        {
            NewAccount.ValidateRegistration();
        }
    }
}
