using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class PageActionMenu : PageObjectForFactory
    {
        [FindsBy(How = How.Id, Using = "action-menu-link")]
        private IWebElement actionMenuButton;

        [FindsBy(How = How.Id, Using = "action-remove-content-link")]
        private IWebElement removeAction;
        
        [FindsBy(How = How.Id, Using = "action-page-permissions-link")]
        private IWebElement editRestrictionsAction;

        [FindsBy(How = How.Id, Using = "s2id_page-restrictions-dialog-selector")]
        private IWebElement restrictionOptionsDropDown;

        public PageActionMenu(IWebDriver driver) : base(driver) { }

        internal void Delete()
        {
            this.Click(removeAction);

            var confirmDeletion = PageFactory.InitElements<DeleteConfirmationPage>(this.driver);
            confirmDeletion.ConfirmButton.Click();
        }

        private void Click(IWebElement menuItem)
        {
            if (this.removeAction.Size.IsEmpty)
            {
                this.actionMenuButton.Click();
            }

            menuItem.Click();
        }

        internal void SetRestrictions(TestData.User user, Enums.Restrictions restrictions)
        {
            this.Click(this.editRestrictionsAction);

            var restrictionsPage = PageFactory.InitElements<Page>(this.driver);

            this.restrictionOptionsDropDown.Click();
            var downTimes = 0;
            switch (restrictions)
            {
                case Enums.Restrictions.ViewOnly:
                    downTimes = 2;
                    break;
            }

            this.SendKey(this.restrictionOptionsDropDown, Keys.ArrowDown, downTimes);
            this.restrictionOptionsDropDown.SendKeys(Keys.Enter);

            var usernameInput = this.driver.FindElement(By.ClassName("select2-input"));
            usernameInput.SendKeys(user.Username);
            Thread.Sleep(500);
            usernameInput.SendKeys(Keys.ArrowDown);
            usernameInput.SendKeys(Keys.Enter);
            var pagePermissionsSelector = this.driver.FindElement(By.Id("page-restrictions-permission-selector"));
            pagePermissionsSelector.Click();
            downTimes = 0;
            switch(restrictions)
            {
                case Enums.Restrictions.ViewOnly:
                    downTimes = 1;
                    break;
            }

            this.SendKey(pagePermissionsSelector, Keys.ArrowDown, downTimes);
            var addButton = this.driver.FindElement(By.Id("page-restrictions-add-button"));
            addButton.Click();

            var saveRestrictionsButton = this.driver.FindElement(By.Id("page-restrictions-dialog-save-button"));
            saveRestrictionsButton.Click();
        }

        private void SendKey(IWebElement element, string key, int times)
        {
            for (int i = 0; i < times; i++)
            {
                element.SendKeys(key);
            }
        }
    }
}
