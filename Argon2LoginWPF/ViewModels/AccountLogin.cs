using Argon2LoginWPF.Models;
namespace Argon2LoginWPF.ViewModels
{
   public class AccountLogin
    {
        /// <summary>
        /// Model property
        /// </summary>
        public Account NewAccount { get; set; }

        /// <summary>
        /// Constractor setting a new instance of the model
        /// </summary>
        public AccountLogin()
        {
            NewAccount = new Account();
        }

        /// <summary>
        /// Model method for login
        /// </summary>
        public void ValidateUser()
        {
            NewAccount.ValidateLogin();
        }
    }
}
