using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TecTest.Utilities.Timing;

namespace TecTest.Utilities.Extensions
{
    public static class WebDriverExtensions
    {
        public static void GlobalSendKeys(this IWebDriver driver, string keys, int times)
        {
            var action = new Actions(driver);
            for (int i = 0; i < times; i++) action.SendKeys(keys).Perform();
        }

        public static void GlobalSendKeys(this IWebDriver driver, string keys)
        {
            var action = new Actions(driver);
            action.SendKeys(keys).Perform();
        }

        public static bool OneElementExists(this IWebDriver driver, By uniqueLocator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Waits.DefaultNotFoundExplicitWaitInSeconds));
            return wait.Until(d => d.FindElements(uniqueLocator)).Count == 1;
        }
    }
}