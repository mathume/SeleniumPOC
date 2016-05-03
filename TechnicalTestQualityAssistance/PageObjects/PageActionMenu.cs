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
            
            var restrictionsPage = PageFactory.InitElements<RestrictionsPage>(this.driver);
            restrictionsPage.AddRestrictions(user, restrictions);
            restrictionsPage.Apply();
        }
    }
}
