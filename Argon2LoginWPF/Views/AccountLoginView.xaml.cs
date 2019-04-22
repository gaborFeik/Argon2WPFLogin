using Argon2LoginWPF.ViewModels;
using System.Windows;


namespace Argon2LoginWPF.Views
{
    /// <summary>
    /// Interaction logic for AccountLoginView.xaml
    /// </summary>
    public partial class AccountLoginView : Window

    {
        /// <summary>
        /// Property for Viewmodel
        /// </summary>
        private readonly AccountLogin _viewModel = new AccountLogin();

        /// <summary>
        /// Constractor setting Datacontext to viewmodel property
        /// </summary>
        public AccountLoginView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        /// <summary>
        /// First layer login method on event click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_ValidateLogin(object sender, RoutedEventArgs e)
        {
            _viewModel.ValidateUser();
        }
    }
}
