using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Timing;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class PageObjectForFactory
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