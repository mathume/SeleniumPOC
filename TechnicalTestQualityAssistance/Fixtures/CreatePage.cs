using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.PageObjects;

namespace TechnicalTestQualityAssistance.Fixtures
{
    [TestFixture]
    public abstract class CreatePage
    {
        protected IWebDriver driver { get; set; }

        public CreatePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [TestFixtureSetUp]
        public void Login()
        {
            this.driver.Navigate().GoToUrl("mathume.atlassian.net/login");
            var loginPage = PageFactory.InitElements<LoginPage>(this.driver);
            loginPage.Login("lwalsh", "82++lwalsh");
            Assert.That(loginPage.Next<ConfluenceDashboard>(), Is.Not.Null, "Couldn't login.");
            this.
        }

        [TestFixtureTearDown]
        public void Logout()
        {

        }

        [Test]
        public void NewPageIsDisplayedAfterCreation()
        {
        }
    }
}
