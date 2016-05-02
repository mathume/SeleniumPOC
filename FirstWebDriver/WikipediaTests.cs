using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using FirstWebDriver.PageObjects;
using FirstWebDriver.Exceptions;

namespace FirstWebDriver
{
    [TestFixture]
    public class WikipediaTests
    {
        private FirefoxDriver driver;
        public WikipediaTests()
        {
            this.driver = new FirefoxDriver();
        }

        [Test]
        public void OpenWikipedia()
        {
            var MainPage = this.MainPage();
            if (TryNavigateTo("https://es.wikipedia.org/wiki/Wikipedia:Portada"))
            {
                MainPage.IsAvailable = true;
            }
            Assert.That(MainPage.BackGroundText.Contains("Bienvenidos"));
        }

        private bool TryNavigateTo(string url)
        {
            try
            {
                this.driver.Navigate().GoToUrl(url);

                return this.driver.Url == url;
            }
            catch(Exception)
            {
                return false;
            }
        }

        [Test]
        public void OpenWikipediaFails()
        {
            var MainPage = this.MainPage();
            if (TryNavigateTo("https://www.wikipedia.es"))
            {
                MainPage.IsAvailable = true;
            }
            var ex = Assert.Throws<PageNotAvailableException>(() =>
                MainPage.BackGroundText.Contains("Bienvenidos"));
            Assert.That(ex.Message, Is.EqualTo("Page not found: MainPage"));
        }

        private MainPage MainPage()
        {
            var MainPage = PageFactory.InitElements<MainPage>(this.driver);
            return MainPage;
        }

        [TearDown]
        public void CloseDriver()
        {
            this.driver.Quit();
        }
    }
}
