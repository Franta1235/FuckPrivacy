using System;
using FuckPrivacy.Users;
using FuckPrivacy.ViewModels;
using NUnit.Framework;
using Xamarin.Forms;

namespace FuckPrivacyTests.ViewModels
{
    [TestFixture]
    public class SignViewModelTest : ContentPage
    {
        [Test]
        public void TestUserExist1() {
            Assert.True(UserManager.UserExist("koznar.franta@gmail.com"));
        }

        [Test]
        public void TestUserExist2() {
            Assert.True(UserManager.UserExist("not.exist@gmail.com") == false);
        }

        [Test]
        public void TestLogin1() {
            var ex = Assert.Throws<ArgumentException>(() => UserManager.SignIn("koznar.franta@gmail.com", "1234", "1234"));
            Assert.True("User exist" == ex.Message);
        }

        [Test]
        public void TestLogin2() {
            var ex = Assert.Throws<ArgumentException>(() => UserManager.SignIn("new.mail@gmail.com", "not", "same"));
            Assert.True("Passwords must be same" == ex.Message);
        }
    }
}