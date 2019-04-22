using Argon2LoginWPF.ViewModels;
using System.Windows;


namespace Argon2LoginWPF.Views
{
    /// <summary>
    /// Interaction logic for AccountCreationView.xaml
    /// </summary>
    public partial class AccountCreationView : Window
    {
        /// <summary>
        /// Property for Viewmodel
        /// </summary>
        private readonly AccountCreation _viewModel = new AccountCreation();

        /// <summary>
        /// Constractor setting Datacontext to viewmodel property
        /// </summary>
        public AccountCreationView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        /// <summary>
        /// First layer registration method on event click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_ValidatePassword(object sender, RoutedEventArgs e)
        {
            _viewModel.ValidateUser();
        }
    }
}
