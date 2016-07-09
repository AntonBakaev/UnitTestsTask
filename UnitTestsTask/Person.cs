namespace UnitTestsTask
{
    public class Person
    {
        public Person(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }
        public string Password { get; private set; }
    }
}
