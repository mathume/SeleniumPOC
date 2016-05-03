using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechnicalTestQualityAssistance.Extensions;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;

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

            pagePermissionsSelector.SendKeys(Keys.ArrowDown, downTimes);

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

            this.restrictionOptionsDropDown.SendKeys(Keys.ArrowDown, downTimes);
            this.restrictionOptionsDropDown.SendKeys(Keys.Enter);
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
