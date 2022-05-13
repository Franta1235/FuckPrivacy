using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using FuckPrivacy.Users;
using Xamarin.Forms;

namespace FuckPrivacy.Users
{
    public class User : AUser
    {
        public User(string username, string password) : base(username, password) {
        }

        public override void StartPage() {
            Application.Current.MainPage = new StartPage(this);
        }
    }
}