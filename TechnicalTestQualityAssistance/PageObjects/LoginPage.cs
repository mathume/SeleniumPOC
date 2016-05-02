using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;
        internal LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        internal PageObject Next<PageObject>() where PageObject : class
        {
            throw new NotImplementedException();
        }
    }
}
