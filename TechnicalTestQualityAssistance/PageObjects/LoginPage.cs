using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.TestData;

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
        
        internal void Login(User login)
        {
            this.username.SendKeys(login.Username);
            this.password.SendKeys(login.Password);
            this.login.Click();
            this.Add<ConfluenceDashboard>();
        }

        internal void Navigate()
        {
            this.driver.Navigate().GoToUrl(Urls.TestSpaceUrl);
        }
    }
}
