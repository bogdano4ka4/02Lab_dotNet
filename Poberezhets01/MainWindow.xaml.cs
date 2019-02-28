using System.Windows.Controls;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;
using Poberezhets01.ViewModels;

namespace Poberezhets01
{
    public partial class MainWindow : IContentOwner
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
