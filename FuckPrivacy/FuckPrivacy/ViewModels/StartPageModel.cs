using System;
using System.ComponentModel;
using System.Windows.Input;
using FuckPrivacy.Pages;
using FuckPrivacy.Users;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class StartPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _text;
        
        public string Text {
            get { return _text; }
            set {
                _text = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }
    }
}