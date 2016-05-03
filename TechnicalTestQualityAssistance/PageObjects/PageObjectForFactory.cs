using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Timing;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class PageObjectForFactory
    {
        protected IWebDriver driver;

        public PageObjectForFactory(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void ClickAndToggleIfNecessary(IWebElement menuButton, IWebElement menuItem)
        {
            if (menuItem.Size.IsEmpty)
            {
                menuButton.Click();
            }

            Waits.DefaultExplicitWait(this.driver).Until(ExpectedConditions.ElementToBeClickable(menuItem));
            menuItem.Click();
        }
    }
}
