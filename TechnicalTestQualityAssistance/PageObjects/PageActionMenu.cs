using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class PageActionMenu : PageObjectForFactory
    {
        [FindsBy(How = How.Id, Using = "action-menu-link")]
        private IWebElement actionMenuButton;

        [FindsBy(How = How.Id, Using = "action-page-permissions-link")]
        private IWebElement editRestrictionsAction;

        [FindsBy(How = How.Id, Using = "action-remove-content-link")]
        private IWebElement removeAction;
        public PageActionMenu(IWebDriver driver)
            : base(driver)
        {
        }

        internal void Delete()
        {
            this.Click(removeAction);

            var confirmDeletion = PageFactory.InitElements<DeleteConfirmationPage>(this.driver);
            confirmDeletion.ConfirmButton.Click();
        }

        internal void SetRestrictions(TestData.User user, Enums.Restrictions restrictions)
        {
            this.Click(this.editRestrictionsAction);

            var restrictionsPage = PageFactory.InitElements<RestrictionsPage>(this.driver);
            restrictionsPage.AddRestrictions(user, restrictions);
            restrictionsPage.Apply();
        }

        private void Click(IWebElement menuItem)
        {
            this.ClickAndToggleIfNecessary(this.actionMenuButton, menuItem);
        }
    }
}