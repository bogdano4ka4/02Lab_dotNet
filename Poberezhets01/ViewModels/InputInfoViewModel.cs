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
        private Person _user;

        #endregion

        #region Commands
        private ICommand _proceedCommand;
        private ICommand _closeCommand;
        #endregion

        public InputInfoViewModel()
        {
            _user = new Person("", "", "");
        }
        #region properties
        public Person MyModel
        {
            get { return _user; }
            set
            {
                _user = value;
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
            DateTime birth = (DateTime)MyModel.Birth;

            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(500);
                    if (!new EmailAddressAttribute().IsValid(MyModel.Email))
                    {
                        MessageBox.Show($"Email address {MyModel.Email}. is not valid.");
                        MyModel.Email = "";
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Email address {MyModel.Email} is not valid");
                    return false;
                }

                if (!GoodBirthday(birth))
                    return false;
                IsBirthday();
                return true;

            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                StationManager.CurrentUser = _user;
                NavigationManager.Instance.Navigate(ViewType.OutputInfo);
            }


        }

        private bool GoodBirthday(DateTime birth)
        {
            DateTime today=DateTime.Today;
            int year = 0;
            if (birth.Month > today.Month || (today.Month == birth.Month && today.Day < birth.Day))
                year = today.Year - birth.Year - 1;
            else year = today.Year - birth.Year;

            if (year < 0 || year > 135)
            {
                MessageBox.Show("Input good value!");
               
                return false;
            }
            return true;
        }

        private void IsBirthday()
        {
            DateTime birth = (DateTime)MyModel.Birth;
            if (birth.Day == DateTime.Today.Day
                && birth.Month == DateTime.Today.Month)
                MessageBox.Show("Happy Birthday!");
        }
        
        private bool CanProceedExecute(object obj)
        {
            return !String.IsNullOrEmpty(MyModel.Name) &&
                   !String.IsNullOrEmpty(MyModel.Surname) &&
                   !String.IsNullOrEmpty(MyModel.Email) && !String.IsNullOrEmpty(MyModel.Birth.ToString());
        }
        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
