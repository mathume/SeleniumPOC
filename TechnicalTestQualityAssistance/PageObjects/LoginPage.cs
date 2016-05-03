using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.TestData;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class LoginPage : PageObjectForFactory
    {
        [FindsBy(How = How.Id)]
        private IWebElement login;

        [FindsBy(How = How.Id)]
        private IWebElement password;

        [FindsBy(How = How.Id)]
        private IWebElement username;
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        internal void Login(User login)
        {
            this.username.SendKeys(login.Username);
            this.password.SendKeys(login.Password);
            this.login.Click();
        }

        internal void Navigate()
        {
            this.driver.Navigate().GoToUrl(Urls.TestSpaceUrl);
        }
    }
}