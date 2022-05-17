using System;
using System.Collections.Generic;
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
        public HomePage() {
            InitializeComponent();
            Text.Text = LoggedUser.User.Username;
        }
    }
}