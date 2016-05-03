using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Specialized;
using TechnicalTestQualityAssistance.Configuration;

namespace TechnicalTestQualityAssistance.Timing
{
    internal static class Waits
    {
        private static NameValueCollection waits = ConfigurationProvider.Instance.Waits;

        public static readonly int DefaultExplicitWaitInSeconds = int.Parse(waits.Get("DefaultExplicitWaitInSeconds"));

        public static readonly int DefaultImplicitWaitInSeconds = int.Parse(waits.Get("DefaultImplicitWaitInSeconds"));

        public static readonly int DefaultNotFoundExplicitWaitInSeconds = int.Parse(waits.Get("DefaultNotFoundExplicitWaitInSeconds"));

        public static readonly int AbsoluteWaitInSecondsFactor = int.Parse(waits.Get("AbsoluteWaitInSecondsFactor"));

        public static void AbsoluteWait(int timeSpanInSeconds)
        {
            Thread.Sleep(timeSpanInSeconds * AbsoluteWaitInSecondsFactor * 1000);
        }

        public static WebDriverWait DefaultExplicitWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultExplicitWaitInSeconds));
        }
    }
}