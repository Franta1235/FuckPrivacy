using FuckPrivacy.Users;
using FuckPrivacy.ViewModels;
using NUnit.Framework;

namespace FuckPrivacyTests.ViewModels
{
    [TestFixture]
    public class SignViewModelTest
    {
        [Test]
        public void TestUserExist1() {
            Assert.True(UserManager.UserExist("koznar.franta@gmail.com"));
        }

        [Test]
        public void TestUserExist2() {
            Assert.True(UserManager.UserExist("not.exist@gmail.com") == false);
        }
    }
}