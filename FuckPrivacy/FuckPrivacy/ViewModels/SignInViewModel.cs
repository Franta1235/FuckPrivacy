using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _email;
        private string _password1;
        private string _password2;


        public string Email {
            get { return _email; }
            set {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password1 {
            get { return _password1; }
            set {
                _password1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string Password2 {
            get { return _password2; }
            set {
                _password2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public SignInViewModel() {
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit() {
            if (Password1 == Password2) {
                // Todo create new User
            }
        }
    }
}