using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechnicalTestQualityAssistance.Extensions;

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
            var usernameInput = this.driver.FindElement(By.ClassName("select2-input"));
            usernameInput.SendKeys(user.Username);
            Thread.Sleep(500);
            usernameInput.SendKeys(Keys.ArrowDown);
            Thread.Sleep(100);
            usernameInput.SendKeys(Keys.Enter);
        }

        private void SelectPermission(Enums.Restrictions restrictions)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(1));
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
            var wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(2));
            wait.Until(IsFocusable(element));
        }
    }
}