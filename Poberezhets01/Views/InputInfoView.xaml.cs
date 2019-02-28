using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Poberezhets01.Tools.Navigation;
using Poberezhets01.ViewModels;

namespace Poberezhets01.Views
{
    /// <summary>
    /// Логика взаимодействия для InputInfoView.xaml
    /// </summary>
    public partial class InputInfoView : UserControl, INavigatable
    {
        public InputInfoView()
        {
            InitializeComponent();
            DataContext = new InputInfoViewModel();
        }

    }
}
