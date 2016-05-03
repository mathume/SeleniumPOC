using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using TechnicalTestQualityAssistance.PageObjects;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.TestData;

namespace TechnicalTestQualityAssistance.Fixtures
{
    [TestFixture]
    abstract class FixtureBaseWithLogin
    {
        protected IWebDriver driver;
        private const double implicitTimeOutInSeconds = 10;
        protected LoginPage loginPage;
        public FixtureBaseWithLogin(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitTimeOutInSeconds));
            this.driver.Manage().Window.Maximize();
            this.loginPage = PageFactory.InitElements<LoginPage>(this.driver);
        }

        [TestFixtureSetUp]
        public void Login()
        {
            this.LoginAsUser(Users.UserWithCreatePagePermission);
            var dashboard = this.loginPage.Next<ConfluenceDashboard>();
            Assert.That(dashboard, Is.Not.Null);
            Assert.That(dashboard.Page.Title, Is.Not.Null.Or.Empty);
        }

        protected void LoginAsUser(User user)
        {
            this.loginPage.Navigate();
            this.loginPage.Login(user);
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
    }
}
