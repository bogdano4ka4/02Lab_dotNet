using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Poberezhets01.Models;
using Poberezhets01.Tools;
using Poberezhets01.Tools.Managers;
using Poberezhets01.Tools.Navigation;
using System.ComponentModel.DataAnnotations;

namespace Poberezhets01.ViewModels
{
    class InputInfoViewModel: BaseViewModel
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime? _birth;
        private DateTime _endDate;
        #endregion

        #region Commands
        private ICommand _proceedCommand;
        private ICommand _closeCommand;
        #endregion

        #region properties

        public InputInfoViewModel()
        {
            _endDate = DateTime.Today;
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        
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
                try
                {
                    Thread.Sleep(1000);
                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        MessageBox.Show($"Email address {_email}. is not valid.");
                        return false;
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show($"Email address {_email} is not valid");
                    return false;
                }
                //TODO birthday ok method
                IsBirthday();

                return true;

            });
            Person person = new Person(FirstName, LastName, Email, (DateTime) Birth);
            StationManager.CurrentUser = person;
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ViewType.OutputInfo);
            FirstName = "";
            LastName = "";
            Email = "";
            Birth = null;
        }

        private void IsBirthday()
        {
            DateTime birthday = (DateTime)_birth;
            if (birthday.Day == DateTime.Today.Day
                && birthday.Month == DateTime.Today.Month)
                MessageBox.Show("Happy Birthday!");
        }
        
        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrEmpty(_firstName) &&
                   !String.IsNullOrEmpty(_lastName) &&
                   !String.IsNullOrEmpty(_email) && !String.IsNullOrEmpty(Birth.ToString());
        }
        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
