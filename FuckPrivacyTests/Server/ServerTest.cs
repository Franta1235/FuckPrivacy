using NUnit.Framework;
using FuckPrivacy.Client;

namespace FuckPrivacyTests.Server
{
    [TestFixture]
    public class ServerTest
    {
        [Test]
        public void TestUserExist1() {
            Assert.IsTrue(AsynchronousClient.UserExist("Franta"));
        }

        [Test]
        public void TestUserExist2() {
            Assert.IsFalse(AsynchronousClient.UserExist("NotExistUserName"));
        }
    }
}