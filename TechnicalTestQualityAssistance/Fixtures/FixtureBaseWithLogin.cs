using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using TechnicalTestQualityAssistance.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.Fixtures
{
    [TestFixture]
    abstract class FixtureBaseWithLogin
    {
        protected IWebDriver driver;
        public FixtureBaseWithLogin(IWebDriver driver)
        {
            this.driver = driver;
        }

        [OneTimeSetUp]
        public void Login()
        {
            this.driver.Navigate().GoToUrl("https://mathume.atlassian.net/wiki/display/TEC");
            var loginPage = PageFactory.InitElements<LoginPage>(this.driver);
            loginPage.Login("lwalsh", "82++lwalsh");
            Assert.That(loginPage.Next<ConfluenceDashboard>(), Is.Not.Null, "Couldn't login.");
        }


        [Test]
        public void CanLogin()
        {
        }

        [TearDown]
        public void CloseCurrentWindow()
        {
            this.driver.Close();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            this.driver.Quit();
        }

    }
}
