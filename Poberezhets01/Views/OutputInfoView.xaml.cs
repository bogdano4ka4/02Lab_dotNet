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
