using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuckPrivacy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetailPage : ContentPage
    {
        public PhotoDetailPage(object sender, EventArgs e) {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed() {
            Application.Current.MainPage = new BottomBarMenu();
            return true;
        }
    }
}