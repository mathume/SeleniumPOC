using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnicalTestQualityAssistance.TestData
{
    class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
