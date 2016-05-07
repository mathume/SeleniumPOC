using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TecTest.Utilities.Extensions;
using TecTest.Utilities.Timing;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class RestrictionsPage : Page
    {
        [FindsBy(How = How.Id, Using = "page-restrictions-add-button")]
        private IWebElement addButton;

        [FindsBy(How = How.Id, Using = "page-restrictions-permission-selector")]
        private IWebElement pagePermissionsSelector;

        [FindsBy(How = How.Id, Using = "s2id_page-restrictions-dialog-selector")]
        private IWebElement restrictionOptionsDropDown;

        [FindsBy(How = How.Id, Using = "page-restrictions-dialog-save-button")]
        private IWebElement saveRestrictionsButton;

        [FindsBy(How = How.ClassName, Using = "select2-input")]
        private IWebElement usernameInput;

        public RestrictionsPage(IWebDriver driver)
            : base(driver)
        {
        }
        internal void AddRestrictions(TestData.User user, Enums.Restrictions restrictions)
        {
            this.SelectRestrictionOption(restrictions);
            this.FillInUser(user);
            this.SelectPermission(restrictions);
            this.addButton.Click();
        }

        internal void Apply()
        {
            this.saveRestrictionsButton.Click();
        }

        private static Func<IWebDriver, bool> IsFocusable(IWebElement element)
        {
            return d => d.SwitchTo().ActiveElement() == element;
        }

        private void FillInUser(TestData.User user)
        {
            this.usernameInput.SendKeys(user.Username);
            Waits.AbsoluteWait(timeSpanInSeconds: 1);
            this.usernameInput.SendKeys(Keys.ArrowDown);
            Waits.AbsoluteWait(timeSpanInSeconds: 1);
            this.usernameInput.SendKeys(Keys.Enter);
        }

        private void SelectPermission(Enums.Restrictions restrictions)
        {
            var wait = Waits.DefaultExplicitWait(this.driver);
            wait.Until(ExpectedConditions.ElementToBeClickable(this.pagePermissionsSelector));
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

        private void WaitForFocus(IWebElement element)
        {
            var wait = Waits.DefaultExplicitWait(this.driver);
            wait.Until(IsFocusable(element));
        }
    }
}