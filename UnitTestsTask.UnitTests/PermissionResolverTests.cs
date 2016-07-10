using System.Collections.Generic;
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
            var accountRep = new AccountRepository();
            accountRep.Accounts = new List<Person>();
            accountRep.Accounts.Add(new Person("Axl", "qwer"));
            accountRep.Accounts.Add(new Person("Ozzy", "12onetwo"));
            accountRep.Accounts.Add(new Person("Bon", "password"));
            permissionResolver = new PermissionResolver(accountRep);
        }

        [TestCase("Axl", "qwer")]
        [TestCase("Ozzy", "12onetwo")]
        [TestCase("Bon", "password")]
        public void HasAccess_GoodVariousInputs_ReturnsTrue(string username, string password)
        {
            Assert.IsTrue(permissionResolver.HasAccess(username, password));
        }

        [TestCase("abra", "cadabra")]
        [TestCase("Bon", "...")]
        [TestCase("...", "qwer")]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void HasAccess_BadVariousInputs_ReturnsFalse(string username, string password)
        {
            Assert.IsFalse(permissionResolver.HasAccess(username, password));
        }
    }
}
