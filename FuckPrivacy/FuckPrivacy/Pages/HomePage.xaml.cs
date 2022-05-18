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


            var stackLayout = new StackLayout() {
                Padding = new Thickness(10, 10, 0, 0),
                Children = {
                    new Frame() {
                        CornerRadius = 5,
                        Padding = 1,
                        Content = new StackLayout() {
                            Orientation = StackOrientation.Horizontal,
                            Children = {
                                new Image() {
                                    Source = "beerIcon",
                                    HeightRequest = 60,
                                    Margin = new Thickness(10, 0, 10, 0)
                                },
                                new Label() {
                                    Text = "My Text",
                                    FontAttributes = FontAttributes.Bold,
                                    Margin = new Thickness(0, 20, 10, 0)
                                }
                            }
                        }
                    }
                }
            };

            var images = new ObservableCollection<StackLayout>();
            images.Add(stackLayout);
            
            Photos.ItemsSource = images;
        }
    }
}