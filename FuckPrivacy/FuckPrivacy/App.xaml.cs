using System;
using FuckPrivacy.Pages;
using FuckPrivacy.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace FuckPrivacy
{
    public partial class App : Application
    {
        public App() {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new LoginPage();
            //MainPage = new BottomBarMenu();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}