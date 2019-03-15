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
using Poberezhets01.Tools.Exceptions;

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
        public Person MyModel => _user;

        #endregion
        #region Commands
        public ICommand ProccedCommand =>
            _proceedCommand ?? (_proceedCommand =
                new RelayCommand<object>(SignUpImplementation, CanProceedExecute));

        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));

        #endregion

        private async void SignUpImplementation(object obj)
        {
            DateTime birth = (DateTime)MyModel.Birth;
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(500);
                try
                {
                   
                    if (!new EmailAddressAttribute().IsValid(MyModel.Email))
                    {
                       throw new IllegalEmailException(MyModel.Email);
                    }
                    GoodBirthday(birth);
                }
                catch (IllegalEmailException ex)
                {
                    MessageBox.Show($"Operation failed.Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
                catch (IllegalDateException ex1)
                {
                    MessageBox.Show($"Operation failed.Reason:{Environment.NewLine} {ex1.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Procced was failed. Reason:{Environment.NewLine} {ex.Message}");
                    return false;
                }
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
                else
                    year = today.Year - birth.Year;
                if (year < 0 || year > 135)
                {
                    throw new IllegalDateException(birth + "");
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
