using System.Collections.Generic;

namespace UnitTestsTask
{
    public interface IAccountRepository
    {
        IEnumerable<Person> GetAccounts();
    }
}
