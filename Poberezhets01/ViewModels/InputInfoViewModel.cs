using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Poberezhets01.Models;
using Poberezhets01.Tools;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;

namespace Poberezhets01.ViewModels
{
    class InputInfoViewModel: BaseViewModel
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime? _birth; //TODO check if ? is nesseccary
        #endregion

        #region Commands
        private ICommand _proceedCommand;
        private ICommand _closeCommand;
        #endregion

        #region properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birth
        {
            get { return _birth; }
            set
            {
                _birth = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        public ICommand ProccedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand =
                           new RelayCommand<object>(SignUpImplementation, CanProceedExecute));
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
        private async void SignUpImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(100);
               
                return true;

            });
            if (Birth != null)
            {
                Person person = new Person(FirstName, LastName, Email, (DateTime) Birth);
                StationManager.CurrentUser = person;
            }

            LoaderManager.Instance.HideLoader();
            if (result) 
                NavigationManager.Instance.Navigate(ViewType.OutputInfo);
            FirstName = "";
            LastName = "";
            Email = "";
            Birth = null;
        }

        private bool CanProceedExecute(object obj)
        {
            return true;
            //return !String.IsNullOrEmpty(_firstName) &&
            //       !String.IsNullOrEmpty(_lastName) &&
            //       !String.IsNullOrEmpty(_email) && !String.IsNullOrEmpty(_birth.ToString());
            ////TODO check if date is !null or valid
        }
        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
          // Environment.Exit(0);
        }
    }
}
