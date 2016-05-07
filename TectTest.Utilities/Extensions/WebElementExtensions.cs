using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TecTest.Utilities.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickWithDelta(this IWebElement element, IWebDriver driver, int offSetX, int offSetY)
        {
            var action = new Actions(driver);
            action
                .MoveToElement(element, offSetX, offSetY)
                .Click();
            action.Perform();
        }

        public static IWebElement GetParent(this IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        public static void SendKeys(this IWebElement element, string keys, int times)
        {
            for (int i = 0; i < times; i++)
            {
                element.SendKeys(keys);
            }
        }
    }
}