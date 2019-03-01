using System.ComponentModel;
using System.Runtime.CompilerServices;
using Poberezhets01.Annotations;
using Poberezhets01.Tools.Navigation;
using Poberezhets01.ViewModels;

namespace Poberezhets01.Views
{ 
    public partial class OutputInfoView : INavigatable
    {
        public OutputInfoView()
        {
            InitializeComponent();
            DataContext = new OutputInfoViewModel();
           
        }
        
    }
}
