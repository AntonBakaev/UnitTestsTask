using System.Linq;

namespace UnitTestsTask
{
    public class PermissionResolver
    {
        private IAccountRepository accountRepository;

        public PermissionResolver(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public bool HasAccess(string username, string password)
        {
            return accountRepository.GetAccounts().Any(ac => ac.Username == username
                                                        && ac.Password == password);
        }
    }
}
