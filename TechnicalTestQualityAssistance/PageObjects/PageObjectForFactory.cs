using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class PageObjectForFactory
    {
        private List<object> nextPages = new List<object>();

        protected IWebDriver driver;

        public PageObjectForFactory(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void Add<T>() where T : class
        {
            this.nextPages.Add(PageFactory.InitElements<T>(this.driver));
        }

        protected void Add(object nextPageObject)
        {
            this.nextPages.Add(nextPageObject);
        }

        public PageObject Next<PageObject>() where PageObject : class
        {
            return (PageObject)this.nextPages.FirstOrDefault(
                p => p.GetType() == typeof(PageObject));
        }
    }
}
