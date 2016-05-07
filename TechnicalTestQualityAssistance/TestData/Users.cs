using System.Collections.Specialized;
using TecTest.Utilities.Configuration;

namespace TechnicalTestQualityAssistance.TestData
{
    internal class Users
    {
        private static NameValueCollection users = ConfigurationProvider.Instance.Logins;

        public static User UserWithCreatePagePermission
        {
            get
            {
                return User("UserWithCreatePagePermission");
            }
        }

        public static User UserWithoutAccessToTestPage
        {
            get
            {
                return User("UserWithoutAccessToTestPage");
            }
        }

        private static User User(string userId)
        {
            var username = users.Get(userId + "Username");
            var password = users.Get(userId + "Password");
            return new User(username, password);
        }
    }
}