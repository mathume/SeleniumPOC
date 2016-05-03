using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.PageObjects;

namespace TechnicalTestQualityAssistance.Fixtures
{
    internal abstract class Login : FixtureBaseWithLogin
    {
        public Login(IWebDriver driver)
            : base(driver)
        {
        }

        [Test]
        public void CanLogin() { }

        [Test]
        public void CanLogout()
        {
            var header = PageFactory.InitElements<Header>(this.driver);
            header.Logout();
        }
    }
}