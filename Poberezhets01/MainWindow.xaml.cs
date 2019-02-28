using System.Windows;
using System.Windows.Controls;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;
using Poberezhets01.ViewModels;
using Poberezhets01.Views;

namespace Poberezhets01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.InputInfo);
           
        }
    }
}
