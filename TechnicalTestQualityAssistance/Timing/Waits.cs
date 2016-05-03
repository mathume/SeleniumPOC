using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalTestQualityAssistance.Configuration;
using OpenQA.Selenium.Support.UI;
using System.Collections.Specialized;
using OpenQA.Selenium;

namespace TechnicalTestQualityAssistance.Timing
{
    static class Waits
    {
        public const int DefaultExplicitWaitInSeconds = 10;

        public const int DefaultImplicitWaitInSeconds = 10;

        public static WebDriverWait DefaultExplicitWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultExplicitWaitInSeconds));
        }
    }
}
