using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FuckPrivacy.Models;
using Xamarin.Forms;

namespace FuckPrivacy.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public string GetProfilePicture() {
            return LoggedUser.User.ProfilePicture;
        }

        public IEnumerable<Photo> GetPhotos() {
            var photos = new ObservableCollection<Photo>();
            for (var i = 0; i < 100; i++) {
                photos.Add(new Photo() {Image = "beerIcon", Text = $"{i.ToString()}"});
            }

            return photos;
        }
        
    }
}