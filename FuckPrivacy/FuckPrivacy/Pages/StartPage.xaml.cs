using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using FuckPrivacy.Users;
using FuckPrivacy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuckPrivacy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage(AUser user) {
            var vm = new StartPageModel();
            this.BindingContext = vm;
            InitializeComponent();

            Text.Text = user.Username;
        }
    }
}