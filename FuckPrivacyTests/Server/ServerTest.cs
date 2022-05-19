using FuckPrivacy.Server;
using NUnit.Framework;

namespace FuckPrivacyTests.Server
{
    [TestFixture]
    public class ServerTest
    {
        [Test]
        public void TestUserExist1() {
            Assert.IsTrue(StaticServer.UserExist("Franta"));
        }
        
        [Test]
        public void TestUserExist2() {
            Assert.IsFalse(StaticServer.UserExist("NotExistUserName"));
        }
    }
}