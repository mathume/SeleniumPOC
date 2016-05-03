using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechnicalTestQualityAssistance.Extensions;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class RestrictionsPage : Page
    {
        public RestrictionsPage(IWebDriver driver) : base(driver) { }

            
        [FindsBy(How = How.Id, Using = "s2id_page-restrictions-dialog-selector")]
        private IWebElement restrictionOptionsDropDown;

        
        internal void AddRestrictions(TestData.User user, Enums.Restrictions restrictions)
        {
            this.SelectRestrictionOption(restrictions);
            this.FillInUser(user);
            this.SelectPermission(restrictions); 
            this.addButton.Click();
        }

        private void SelectPermission(Enums.Restrictions restrictions)
        {
            this.pagePermissionsSelector.Click();

            var downTimes = 0;
            switch (restrictions)
            {
                case Enums.Restrictions.ViewOnly:
                    downTimes = 1;
                    break;
            }

            this.driver.GlobalSendKeys(Keys.ArrowDown, downTimes);

        }

        private void WaitForFocus(IWebElement element)
        {
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(2));
            wait.Until(IsFocusable(element));
        }

        private static Func<IWebDriver, bool> IsFocusable(IWebElement element)
        {
            return d => d.SwitchTo().ActiveElement() == element;
        }

        [FindsBy(How = How.Id, Using = "page-restrictions-add-button")]
        private IWebElement addButton;
            

        private void FillInUser(TestData.User user)
        {
            var usernameInput = this.driver.FindElement(By.ClassName("select2-input"));
            usernameInput.SendKeys(user.Username);
            Thread.Sleep(500);
            usernameInput.SendKeys(Keys.ArrowDown);
            usernameInput.SendKeys(Keys.Enter);
        }

        private void SelectRestrictionOption(Enums.Restrictions restrictions)
        {
            this.restrictionOptionsDropDown.Click();

            var downTimes = 0;
            switch (restrictions)
            {
                case Enums.Restrictions.ViewOnly:
                    downTimes = 2;
                    break;
            }

            this.driver.GlobalSendKeys(Keys.ArrowDown, downTimes);
            this.driver.GlobalSendKeys(Keys.Enter);
        }

        [FindsBy(How = How.Id, Using = "page-restrictions-dialog-save-button")]
        private IWebElement saveRestrictionsButton;

        internal void Apply()
        {
            this.saveRestrictionsButton.Click();
        }

        [FindsBy(How = How.Id, Using = "page-restrictions-permission-selector")]
        private IWebElement pagePermissionsSelector;
            

    }
}
