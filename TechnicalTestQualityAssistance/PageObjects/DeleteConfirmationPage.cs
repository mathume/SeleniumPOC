using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class DeleteConfirmationPage : Page
    {
        [FindsBy(How = How.Id, Using = "confirm")]
        private IWebElement confirmButton;

        public DeleteConfirmationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement ConfirmButton
        {
            get
            {
                return this.confirmButton;
            }
        }
    }
}