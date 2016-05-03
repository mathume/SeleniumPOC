using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Extensions;
using TechnicalTestQualityAssistance.Timing;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class Header : PageObjectForFactory
    {
        public Header(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "quick-create-page-button")]
        private IWebElement quickCreatePageButton;

        private const string userMenuId = "user-menu-link";

        [FindsBy(How = How.Id, Using = userMenuId)]
        private IWebElement userMenu;

        private const string logoutItemId = "logout-link";

        [FindsBy(How = How.Id, Using = logoutItemId)]
        private IWebElement logoutItem;

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
