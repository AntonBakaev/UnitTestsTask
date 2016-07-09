using System.Collections.Generic;

namespace UnitTestsTask
{
    public class AccountRepository : IAccountRepository
    {
        private List<Person> accounts;

        public AccountRepository()
        {
            accounts = new List<Person>();
            accounts.Add(new Person("Mike", "password"));
            accounts.Add(new Person("Jack", "qwerty"));
            accounts.Add(new Person("Tom", "1234pass"));
            accounts.Add(new Person("Jerry", "secretpassword"));
            accounts.Add(new Person("Max", "123"));
        }

        public IEnumerable<Person> GetAccounts()
        {
            return accounts;
        }
    }
}
