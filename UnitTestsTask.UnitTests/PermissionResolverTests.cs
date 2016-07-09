using NUnit.Framework;

namespace UnitTestsTask.UnitTests
{
    [TestFixture]
    public class PermissionResolverTests
    {
        private PermissionResolver permissionResolver;

        [SetUp]
        public void SetUp()
        {
            IAccountRepository accountRep = new AccountRepository();
            permissionResolver = new PermissionResolver(accountRep);
        }

        [TestCase("Mike", "password")]
        [TestCase("Tom", "1234pass")]
        [TestCase("Max", "123")]
        public void HasAccess_GoodVariousInputs_ReturnsTrue(string username, string password)
        {
            Assert.IsTrue(permissionResolver.HasAccess(username, password));
        }

        [TestCase("abra", "cadabra")]
        [TestCase("Tom", "...")]
        [TestCase("...", "123")]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void HasAccess_BadVariousInputs_ReturnsFalse(string username, string password)
        {
            Assert.IsFalse(permissionResolver.HasAccess(username, password));
        }
    }
}
