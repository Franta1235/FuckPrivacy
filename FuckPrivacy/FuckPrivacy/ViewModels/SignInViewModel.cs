using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string email;
        private string password1;
        private string password2;


        public string Email {
            get { return email; }
            set {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password1 {
            get { return password1; }
            set {
                password1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public string Password2 {
            get { return password2; }
            set {
                password2 = value;
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