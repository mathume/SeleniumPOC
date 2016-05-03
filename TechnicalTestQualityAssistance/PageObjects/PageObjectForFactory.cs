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
        protected IWebDriver driver;

        public PageObjectForFactory(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
