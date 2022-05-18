using System;
using System.Collections.Generic;
using FuckPrivacy.Pages;
using Xamarin.Forms;

namespace FuckPrivacy.Users
{
    public class User : AUser
    {
        public List<Friend> Friends;
        public List<CloseFriend> CloseFriends;
        
        public override void HomePage() {
            Application.Current.MainPage = new BottomBarMenu();
        }

        protected List<Friend> GetFriends() {
            throw new NotImplementedException();
        }

        protected List<CloseFriend> GetCloseFriends() {
            throw new NotImplementedException();
        }
    }
}