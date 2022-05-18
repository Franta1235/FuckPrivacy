using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckPrivacy.Users;
using FuckPrivacy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuckPrivacy.Pages
{
    public class Photo
    {
        public string Image { get; set; }
        public string Text { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly AUser _user;

        public HomePage() {
            _user = LoggedUser.User;
            InitializeComponent();
            ProfilePicture.Source = _user.ProfilePicture;
            var vm = new HomePageViewModel();
            BindingContext = vm;

            var photos = new ObservableCollection<Photo>();
            for (var i = 0; i < 100; i++) {
                photos.Add(new Photo() {Image = "beerIcon", Text = $"{i.ToString()}"});
            }


            Photos.ItemsSource = photos;
        }
    }
}