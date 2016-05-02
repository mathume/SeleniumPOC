using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class LoginPage : PageObjectForFactory
    {
        [FindsBy(How = How.Id)]
        private IWebElement username;

        [FindsBy(How = How.Id)]
        private IWebElement password;

        [FindsBy(How = How.Id)]
        private IWebElement login;

        public LoginPage(IWebDriver driver) : base(driver) { }
        
        internal void Login(string username, string password)
        {
            this.username.SendKeys(username);
            this.password.SendKeys(password);
            this.login.Click();
            this.Add<ConfluenceDashboard>();
        }
    }
}
