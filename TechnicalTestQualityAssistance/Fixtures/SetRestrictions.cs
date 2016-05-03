using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Enums;
using TechnicalTestQualityAssistance.PageObjects;
using TechnicalTestQualityAssistance.TestData;
using TechnicalTestQualityAssistance.Timing;

namespace TechnicalTestQualityAssistance.Fixtures
{
    internal abstract class SetRestrictions : FixtureBaseWithLogin
    {
        private Header header;
        private Page page;
        private string testPageUrl;
        public SetRestrictions(IWebDriver driver)
            : base(driver)
        {
            this.page = PageFactory.InitElements<Page>(this.driver);
            this.header = PageFactory.InitElements<Header>(this.driver);
        }

        [Test]
        public void CheckSetViewOnlyRestrictionsForUser()
        {
            this.SetViewOnlyRestrictionsForUser(Users.UserWithoutAccessToTestPage);
            this.Logout();
            this.LoginAsUser(Users.UserWithoutAccessToTestPage);
            this.driver.Navigate().GoToUrl(this.testPageUrl);
            Assert.That(this.page.Title, Is.Not.Null.Or.Empty);
            Assert.That(this.page.CanEdit, Is.False);
        }

        [Test]
        public void CanSetViewOnlyRestrictionsForUser()
        {
            this.SetViewOnlyRestrictionsForUser(Users.UserWithoutAccessToTestPage);
        }

        [SetUp]
        public void SetUp()
        {
            this.CreateTestPage();
        }

        [TearDown]
        public void TearDown()
        {
            this.Logout();
            this.TryDeletePage();
        }

        private void TryDeletePage()
        {
            try
            {
                this.LoginAsUser(Users.UserWithCreatePagePermission);
                this.driver.Navigate().GoToUrl(this.testPageUrl);
                var testPage = PageFactory.InitElements<Page>(this.driver);
                testPage.ActionMenu.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't delete created page. " + e.Message);
            }
        }

        private void AssertThatUserCannotEditPage(User user, Page page)
        {
            this.loginPage.Navigate();
            this.loginPage.Login(user);
            this.page.Navigate(this.testPageUrl);
            Assert.That(page.Title, Is.Not.Null.Or.Empty);
            Assert.That(page.CanEdit, Is.False);
        }

        private void CreateTestPage()
        {
            var title = "new page" + Guid.NewGuid();
            var dashboard = PageFactory.InitElements<ConfluenceDashboard>(this.driver);
            this.header = dashboard.Header;
            this.header.CreatePage(title);
            this.testPageUrl = this.driver.Url;
        }
        private void Logout()
        {
            this.header.Logout();
        }

        private void SetViewOnlyRestrictionsForUser(User user)
        {
            this.page.Navigate(this.testPageUrl);
            var title = this.page.Title;
            this.page.ActionMenu.SetRestrictions(user, Restrictions.ViewOnly);
            var wait = Waits.DefaultExplicitWait(this.driver);
            wait.Until(ExpectedConditions.ElementToBeClickable(this.page.title_text));
            this.driver.Navigate().Refresh();
        }
    }
}