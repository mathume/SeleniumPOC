using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class LogoutConfirmationPage : PageObjectForFactory
    {
        [FindsBy(How = How.Id, Using = "logout")]
        private IWebElement logoutButton;

        public LogoutConfirmationPage(IWebDriver driver)
            : base(driver)
        {
        }
        public void Confirm()
        {
            this.logoutButton.Click();
        }
    }
}