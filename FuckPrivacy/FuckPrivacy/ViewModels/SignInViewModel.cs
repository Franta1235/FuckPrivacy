using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using FuckPrivacy.Pages;
using FuckPrivacy.Users;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public Action DisplayUserExistPrompt;
        public Action DisplayPasswordsNotEqualsPrompt;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _email;
        private string _password1;
        private string _password2;


        private string Email {
            get => _email;
            set {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string Password1 {
            get => _password1;
            set {
                _password1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string Password2 {
            get => _password2;
            set {
                _password2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public SignInViewModel() {
            SubmitCommand = new Command(OnSubmit);
        }
        
        private void OnSubmit() {
            UserManager.SignIn(Email,Password1,Password2).StartPage();
        }
    }
}