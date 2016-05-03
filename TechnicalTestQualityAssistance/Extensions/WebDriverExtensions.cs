using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TechnicalTestQualityAssistance.Extensions
{
    static class WebDriverExtensions
    {
        public static void GlobalSendKeys(this IWebDriver driver, string keys, int times)
        {
            var action = new Actions(driver);
            for(int i=0; i<times; i++) action.SendKeys(keys).Perform();
        }

        public static void GlobalSendKeys(this IWebDriver driver, string keys)
        {
            var action = new Actions(driver);
            action.SendKeys(keys).Perform();
        }
    }
}
