using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    class Login : Fixtures.Login
    {
        public Login() : base(DriverProvider.New<FirefoxDriver>()) { }
    }
}
