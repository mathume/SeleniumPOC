using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechnicalTestQualityAssistance.PageObjects;

namespace TechnicalTestQualityAssistance.Fixtures
{
    [TestFixture]
    internal abstract class CreatePage : FixtureBaseWithLogin
    {
        private Page currentPage;

        public CreatePage(IWebDriver driver)
            : base(driver)
        {
        }

        [TearDown]
        public void DeleteCreatedPage()
        {
            try
            {
                this.currentPage.ActionMenu.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't delete current page. " + e.Message);
            }
        }

        [Test]
        public void NewPageIsDisplayedAfterCreation()
        {
            var newPageTitle = "new title" + Guid.NewGuid();
            var header = PageFactory.InitElements<Header>(this.driver);
            header.CreatePage(newPageTitle);
            this.currentPage = PageFactory.InitElements<Page>(this.driver);

            Assert.That(currentPage.Title, Is.EqualTo(newPageTitle));
        }

        [Test]
        public void NewPageCanBeEdited()
        {
            var newPageTitle = "new title" + Guid.NewGuid();
            var header = PageFactory.InitElements<Header>(this.driver);
            header.CreatePage(newPageTitle);
            this.currentPage = PageFactory.InitElements<Page>(this.driver);

            Assert.That(this.currentPage.CanEdit, Is.True);
        }
    }
}