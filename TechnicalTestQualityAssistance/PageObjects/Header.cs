using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class Header : PageObjectForFactory
    {
        public Header(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "quick-create-page-button")]
        private IWebElement quickCreatePageButton;

        [FindsBy(How = How.Id, Using = "user-menu-link")]
        private IWebElement userMenu;

        [FindsBy(How = How.Id, Using = "logout-link")]
        private IWebElement logoutItem;

        internal void CreatePage(string title)
        {
            quickCreatePageButton.Click();
            var page = PageFactory.InitElements<Page>(this.driver);
            
            page.SetTitle(title);
            page.Save();
            this.Add(page);
        }

        internal void Logout()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(this.userMenu));
            this.userMenu.FindElement(By.TagName("img")).Click();
            this.logoutItem.Click();
            var confirmationPage = PageFactory.InitElements<LogoutConfirmationPage>(this.driver);
            confirmationPage.Confirm();
        }
    }
}
