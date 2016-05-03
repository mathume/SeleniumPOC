using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TechnicalTestQualityAssistance.Timing
{
    internal static class Waits
    {
        public const int DefaultExplicitWaitInSeconds = 10;

        public const int DefaultImplicitWaitInSeconds = 10;

        public const int DefaultNotFoundExplicitWaitInSeconds = 3;

        public static WebDriverWait DefaultExplicitWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultExplicitWaitInSeconds));
        }
    }
}