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
    abstract class CreatePage : FixtureBaseWithLogin
    {
        private Page currentPage;
        
        public CreatePage(IWebDriver driver) : base(driver) { }

        [Test]
        public void NewPageIsDisplayedAfterCreation()
        {
            var newPageTitle = "new title" + Guid.NewGuid();
            var header = PageFactory.InitElements<Header>(this.driver);
            header.CreatePage(newPageTitle);
            this.currentPage = header.Next<Page>();
            Assert.That(currentPage.MainHeader, Is.EqualTo(newPageTitle));
        }

        [TearDown]
        public void DeleteCreatedPage()
        {
            //this.currentPage.Menu.Delete();
        }
    }
}
