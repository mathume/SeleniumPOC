using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    class Login : Fixtures.Login
    {
        public Login() : base(new FirefoxDriver()) { }
    }
}
