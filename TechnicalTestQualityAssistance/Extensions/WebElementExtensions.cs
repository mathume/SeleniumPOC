using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace TechnicalTestQualityAssistance.Extensions
{
    static class WebElementExtensions
    {
        public static void SendKeys(this IWebElement element, string keys, int times)
        {
            for (int i = 0; i < times; i++)
            {
                element.SendKeys(keys);
            }
        }

        public static void ClickWithDelta(this IWebElement element, IWebDriver driver, int offSetX, int offSetY)
        {
            var action = new Actions(driver);
            action
                .MoveToElement(element, offSetX, offSetY)
                .Click();
            action.Perform();
        }
    }
}
