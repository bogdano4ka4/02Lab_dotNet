using System;
using System.Windows.Input;
using Poberezhets01.Models;
using Poberezhets01.Tools;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;

namespace Poberezhets01.ViewModels
{
    class OutputInfoViewModel: BaseViewModel
    {
        private Person _person;
        #region Fields
        #endregion
        
        #region Commands
        private ICommand _backCommand;
        private ICommand _closeCommand;
        #endregion
      

        #region properties
        public Person Person
        {
            get { return _person; }
            set { _person = value; OnPropertyChanged(); }
        }
        public string FirstName
        {
            get { return StationManager.CurrentUser.Name; }
        }
        public string LastName
        {
            get { return StationManager.CurrentUser.Surname; }
        }
        public string Email
        {
            get { return StationManager.CurrentUser.Email; }
        }
        public DateTime Birth
        {
            get { return StationManager.CurrentUser.Birth ; }
        }
        public bool Adult
        {
            get { return StationManager.CurrentUser.IsAdult; }
        }
        public string SunSign
        {
            get { return StationManager.CurrentUser.SunSign; }
        }
        public string ChineseSign
        {
            get { return StationManager.CurrentUser.ChineseSign; }
        }
        public bool IsBirthday
        {
            get { return StationManager.CurrentUser.IsBirthday; }
        }
        #endregion
        #region Commands
        public ICommand BackCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(BackMenuCommand));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));
            }
        }
        #endregion

       
       
        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
        private void BackMenuCommand(object obj)
        {

           NavigationManager.Instance.Navigate(ViewType.InputInfo);
        }

    }
}
