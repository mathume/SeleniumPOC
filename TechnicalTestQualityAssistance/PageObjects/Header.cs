using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Extensions;

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
            var clickableUserMenu = this.userMenu.FindElement(By.TagName("img"));
            clickableUserMenu.ClickWithDelta(this.driver, 0, -1);
            this.logoutItem.Click();
            var confirmationPage = PageFactory.InitElements<LogoutConfirmationPage>(this.driver);
            confirmationPage.Confirm();
        }
    }
}
