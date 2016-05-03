using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.PageObjects;
using TechnicalTestQualityAssistance.TestData;
using TechnicalTestQualityAssistance.Timing;

namespace TechnicalTestQualityAssistance.Fixtures
{
    [TestFixture]
    internal abstract class FixtureBaseWithLogin
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;

        public FixtureBaseWithLogin(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Waits.DefaultImplicitWaitInSeconds));
            this.driver.Manage().Window.Maximize();
            this.loginPage = PageFactory.InitElements<LoginPage>(this.driver);
        }

        [TearDown]
        public void CloseCurrentWindow()
        {
            this.driver.Close();
        }

        [TestFixtureTearDown]
        public void CloseDriver()
        {
            this.driver.Quit();
        }

        [TestFixtureSetUp]
        public void Login()
        {
            this.LoginAsUser(Users.UserWithCreatePagePermission);
            var dashboard = PageFactory.InitElements<ConfluenceDashboard>(this.driver);
            Assert.That(dashboard, Is.Not.Null);
            Assert.That(dashboard.Page.Title, Is.Not.Null.Or.Empty);
        }

        protected void LoginAsUser(User user)
        {
            this.loginPage.Navigate();
            this.loginPage.Login(user);
        }
    }
}