using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using FuckPrivacy.Users;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _email;

        private string _password;

        public string Email {
            get => _email;
            set {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password {
            get => _password;
            set {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public ICommand SignInCommand { set; get; }

        public LoginViewModel() {
            SubmitCommand = new Command(OnSubmit);
            SignInCommand = new Command(OnSignIn);
        }

        private void OnSubmit() {
            try {
                var user = UserManager.Login(Email, Password);
                LoggedUser.User = user;
                user.HomePage();
            }
            catch (ArgumentException) {
                DisplayInvalidLoginPrompt();
            }
        }

        private static void OnSignIn() {
            Application.Current.MainPage = new SignInPage();
        }
    }
}