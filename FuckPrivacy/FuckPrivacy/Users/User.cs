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
        public User(string username) : base(username) {
        }

        public override void StartPage() {
            Application.Current.MainPage = new StartPage(this);
        }
    }
}