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


        public string Email {
            get => _email;
            set {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password1 {
            get => _password1;
            set {
                _password1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password1"));
            }
        }

        public string Password2 {
            get => _password2;
            set {
                _password2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password2"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public SignInViewModel() {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit() {
            try {
                UserManager.SignIn(Email, Password1, Password2).StartPage();
            }
            catch (ArgumentException e) {
                switch (e.Message) {
                    case "User exist":
                        DisplayUserExistPrompt();
                        break;
                    case "Passwords must be same":
                        DisplayPasswordsNotEqualsPrompt();
                        break;
                }
            }
        }
    }
}