using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TecTest.Utilities.Extensions;
using TecTest.Utilities.Timing;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class Header : PageObjectForFactory
    {
        private const string logoutItemId = "logout-link";

        private const string userMenuId = "user-menu-link";

        [FindsBy(How = How.Id, Using = logoutItemId)]
        private IWebElement logoutItem;

        [FindsBy(How = How.Id, Using = "quick-create-page-button")]
        private IWebElement quickCreatePageButton;

        [FindsBy(How = How.Id, Using = userMenuId)]
        private IWebElement userMenu; // is not clickable in some browsers, click on parent works

        public Header(IWebDriver driver)
            : base(driver)
        {
        }
        internal void CreatePage(string title)
        {
            quickCreatePageButton.Click();
            var page = PageFactory.InitElements<Page>(this.driver);
            page.SetTitle(title);
            page.SaveAndWaitForTitle();
        }

        internal void Logout()
        {
            Waits.DefaultExplicitWait(this.driver).Until(ExpectedConditions.ElementIsVisible(By.Id(userMenuId)));
            this.userMenu.GetParent().Click();
            Waits.DefaultExplicitWait(this.driver).Until(ExpectedConditions.ElementToBeClickable(this.logoutItem));
            this.logoutItem.Click();
            var confirmationPage = PageFactory.InitElements<LogoutConfirmationPage>(this.driver);
            confirmationPage.Confirm();
        }
    }
}