using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TechnicalTestQualityAssistance.Fixtures
{
    abstract class Login : FixtureBaseWithLogin
    {
        public Login(IWebDriver driver) : base(driver) { }

        [Test]
        public void CanLogin()
        {
        }
    }
}
