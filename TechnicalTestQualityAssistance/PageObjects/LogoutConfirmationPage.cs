using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class LogoutConfirmationPage : PageObjectForFactory
    {
        public LogoutConfirmationPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "logout")]
        private IWebElement logoutButton;

        public void Confirm()
        {
            this.logoutButton.Click();
        }
    }
}
