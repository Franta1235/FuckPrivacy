﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string email;

        private string password;

        public string Email {
            get { return email; }
            set {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password {
            get { return password; }
            set {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public ICommand SignInCommand { protected set; get; }

        public LoginViewModel() {
            SubmitCommand = new Command(OnSubmit);
            SignInCommand = new Command(OnSignIn);
        }

        public void OnSubmit() {
            // Todo Get user and login
        }

        public void OnSignIn() {
            Application.Current.MainPage = new SignInPage();
        }
    }
}