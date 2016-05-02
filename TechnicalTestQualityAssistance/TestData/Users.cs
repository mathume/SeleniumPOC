using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnicalTestQualityAssistance.TestData
{
    class Users
    {
        public static User UserWithCreatePagePermission
        {
            get
            {
                return new User("lwalsh", "82++lwalsh");
            }
        }

        public static User UserWithoutAccessToTestPage
        {
            get
            {
                return new User("restricted", "82++restricted");
            }
        }
    }
}
