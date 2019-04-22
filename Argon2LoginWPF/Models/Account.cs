using Argon2LoginWPF.ViewModels;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Argon2LoginWPF.Models
{
    /// <summary>
    /// Account model 
    /// </summary>
    public class Account : INotifyPropertyChanged
    {
        /// <summary>
        /// Private fields combined with public properties
        /// </summary>
        private string _name;
        private string _password;
        private string _validationMessage;

        /// <summary>
        /// Name notifies event on change
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// Password notifies event on change
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary>
        /// ValidationMessage notifies event on change
        /// </summary>
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                _validationMessage = value;

                OnPropertyChanged(nameof(ValidationMessage));
            }
        }

        /// <summary>
        /// Method to publish events
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Declaration for event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private regex method for valid password registration
        /// </summary>
        /// <returns> returns true on valid password</returns>
        private bool ValidationPassword()
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (!hasNumber.IsMatch(Password))
            {
                ValidationMessage = "Password must contain at least one number";
                return false;
            }
            else if (!hasUpperChar.IsMatch(Password))
            {
                ValidationMessage = "Password must contain at least one upper case character";
                return false;

            }
            else if (!hasMinimum8Chars.IsMatch(Password))
            {
                ValidationMessage = "Password must be at least 8 character long";
                return false;

            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Private method for valid username registration
        /// </summary>
        /// <returns>Returns true on valid username</returns>
        private bool ValidateUsername()
        {
            var hasMinimum8Chars = new Regex(@" ^[a - zA - Z]{ 1 }[a - zA - Z0 - 9\._\-]{ 0,23}[^.-]$");

            if (hasMinimum8Chars.IsMatch(Name))
            {
                ValidationMessage = "Incorrect username";
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method checks if the username and passwords are valid and calls register view 
        /// </summary>
        public void ValidateRegistration()
        {
            if (ValidateUsername() && ValidationPassword())
            {
                var registerView = new AccountControlView().Register(this);
                ValidationMessage = registerView.ValidationMessage;
            }
        }

        /// <summary>
        /// Method calls login view
        /// </summary>
        public void ValidateLogin()
        {
            var registerView = new AccountControlView().Login(this);
            ValidationMessage = registerView.ValidationMessage;
        }

    }


}
