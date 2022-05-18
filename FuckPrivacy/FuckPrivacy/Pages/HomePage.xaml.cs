using System;
using FuckPrivacy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuckPrivacy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage() {
            InitializeComponent();
            var vm = new HomePageViewModel();
            BindingContext = vm;

            ProfilePicture.Source = vm.GetProfilePicture();
            Photos.ItemsSource = vm.GetPhotos();
        }

        private void ImageButton_OnClicked(object sender, EventArgs e) {
            Application.Current.MainPage = new PhotoDetailPage(sender, e);
        }
    }
}