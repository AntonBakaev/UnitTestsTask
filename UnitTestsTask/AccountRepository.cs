using System.Collections.Generic;

namespace UnitTestsTask
{
    public class AccountRepository : IAccountRepository
    {
        private List<Person> accounts;

        public AccountRepository()
        {
            Accounts = new List<Person>();
            Accounts.Add(new Person("Mike", "password"));
            Accounts.Add(new Person("Jack", "qwerty"));
            Accounts.Add(new Person("Tom", "1234pass"));
            Accounts.Add(new Person("Jerry", "secretpassword"));
            Accounts.Add(new Person("Max", "123"));
        }

        public List<Person> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }

        public IEnumerable<Person> GetAccounts()
        {
            return accounts;
        }
    }
}
