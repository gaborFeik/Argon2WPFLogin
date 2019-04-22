using Argon2LoginWPF.Views;
using System.Windows;


namespace Argon2LoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Login window onClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnClick_Login(object sender, RoutedEventArgs e)
        {
            AccountLoginView view = new AccountLoginView();
            view.ShowDialog();
        }

        /// <summary>
        /// Register window onClick event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnClick_Register(object sender, RoutedEventArgs e)
        {
            AccountCreationView view = new AccountCreationView();
            view.ShowDialog();
        }
    }
}
