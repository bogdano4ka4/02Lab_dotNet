using System.Windows.Input;
using Poberezhets01.Models;
using Poberezhets01.Tools;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;

namespace Poberezhets01.ViewModels
{
    class OutputInfoViewModel: BaseViewModel
    {
        private Person _user = StationManager.CurrentUser;
        #region Commands
        private ICommand _backCommand;
        private ICommand _closeCommand;
        #endregion
        
        #region properties
        public Person MyModel
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
       
        #endregion
        #region Commands
        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand<object>(BackMenuCommand));
        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));

        #endregion
        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }

        private void BackMenuCommand(object obj)
        {
            MyModel.Name = "";
            MyModel.Surname = "";
            MyModel.Birth = null;
            MyModel.Email = "";
            NavigationManager.Instance.Navigate(ViewType.InputInfo);
        }
    }
}
