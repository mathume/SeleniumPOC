using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class ConfluenceDashboard : PageObjectForFactory
    {
        public ConfluenceDashboard(IWebDriver driver)
            : base(driver)
        {
            this.Header = PageFactory.InitElements<Header>(this.driver);
            this.Page = PageFactory.InitElements<Page>(this.driver);
        }

        public Header Header { get; private set; }

        public Page Page { get; private set; }
    }
}