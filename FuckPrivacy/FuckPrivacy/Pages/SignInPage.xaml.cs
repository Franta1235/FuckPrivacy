using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuckPrivacy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FuckPrivacy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public SignInPage() {
            var vm = new SignInViewModel();
            BindingContext = vm;
            vm.DisplayUserExistPrompt += () => DisplayAlert("Error", $"User already exist.", "OK");
            vm.DisplayPasswordsNotEqualsPrompt += () => DisplayAlert("Error", $"Passwords are not same.", "OK");
            InitializeComponent();
            
            Email.Completed += (object sender, EventArgs e) => {
                Password1.Focus();
                Password2.Focus();
            };
            Password1.Completed += (object sender, EventArgs e) => { vm.SubmitCommand.Execute(null); };
            Password2.Completed += (object sender, EventArgs e) => { vm.SubmitCommand.Execute(null); };
        }
    }
}