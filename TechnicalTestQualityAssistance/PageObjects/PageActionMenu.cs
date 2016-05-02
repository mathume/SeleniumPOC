using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class PageActionMenu : PageObjectForFactory
    {
        [FindsBy(How = How.Id, Using = "action-menu-link")]
        private IWebElement actionMenuButton;

        [FindsBy(How = How.Id, Using = "action-remove-content-link")]
        private IWebElement removeAction;

        public PageActionMenu(IWebDriver driver) : base(driver) { }

        internal void Delete()
        {
            if (removeAction.Size.IsEmpty)
            {
                this.actionMenuButton.Click();
            }

            removeAction.Click();

            var confirmDeletion = PageFactory.InitElements<Page>(this.driver);
            confirmDeletion.ConfirmButton.Click();
        }
    }
}
