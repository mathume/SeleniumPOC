﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.PageObjects;
using TechnicalTestQualityAssistance.TestData;
using TechnicalTestQualityAssistance.Enums;
using OpenQA.Selenium;

namespace TechnicalTestQualityAssistance.Fixtures
{
    abstract class SetRestrictions : FixtureBaseWithLogin
    {
        private string testPageUrl;
        private Page page;
        private Header header;

        public SetRestrictions(IWebDriver driver) : base(driver) 
        {
            this.page = PageFactory.InitElements<Page>(this.driver);
            this.header = PageFactory.InitElements<Header>(this.driver);
        }

        private void CreatePage()
        {
            var title = "new page" + Guid.NewGuid();
            var dashboard = PageFactory.InitElements<ConfluenceDashboard>(this.driver);
            this.header = dashboard.Header;
            this.header.CreatePage(title);
            if (!this.driver.Url.Contains(title.Replace(" ", "+")))
            {
                var page = dashboard.Header.Next<Page>();
                page.SetTitle(title);
                page.Save();
            }
            this.testPageUrl = this.driver.Url;
        }

        [Test]
        public void CheckSetRestrictions()
        {
            this.CreatePage();
            this.SetViewOnlyRestrictionsForUser(Users.UserWithoutAccessToTestPage);
            this.Logout();
            this.LoginAsUser(Users.UserWithoutAccessToTestPage);
            this.driver.Navigate().GoToUrl(this.testPageUrl);
            Assert.That(this.page.Title, Is.Not.Null.Or.Empty);
            Assert.That(this.page.CanEdit, Is.False);
        }

        private void Logout()
        {
            this.header.Logout();
        }

        private void SetViewOnlyRestrictionsForUser(User user)
        {
            
            this.page.Navigate(this.testPageUrl);
            this.page.ActionMenu.SetRestrictions(user, Restrictions.ViewOnly);
        }

        private void AssertThatUserCannotEditPage(User user, Page page)
        {
            this.loginPage.Navigate();
            this.loginPage.Login(user);
            this.page.Navigate(this.testPageUrl);
            Assert.That(page.Title, Is.Not.Null.Or.Empty);
            Assert.That(page.CanEdit, Is.False);
        }
    }
}