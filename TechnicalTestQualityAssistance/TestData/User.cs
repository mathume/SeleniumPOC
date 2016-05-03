namespace TechnicalTestQualityAssistance.TestData
{
    internal class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}