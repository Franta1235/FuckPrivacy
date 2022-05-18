using System;
using System.Collections.Generic;
using FuckPrivacy.Pages;
using Xamarin.Forms;

namespace FuckPrivacy.Users
{
    public abstract class AUser
    {
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public abstract void HomePage();
    }
}