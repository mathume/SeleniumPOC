using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class Page : PageObjectForFactory
    {
        private const string editButtonId = "editPageLink";

        private const string titleTextId = "title-text";

        [FindsBy(How = How.Id, Using = editButtonId)]
        private IWebElement editButton;

        [FindsBy(How = How.Id, Using = "rte-button-publish")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "content-title")]
        private IWebElement title;

        public Page(IWebDriver driver)
            : base(driver)
        {
            this.ActionMenu = PageFactory.InitElements<PageActionMenu>(this.driver);
        }
        public PageActionMenu ActionMenu { get; private set; }

        public bool CanEdit
        {
            get
            {
                return this.driver.FindElements(By.Id("editButtonId")).Count() == 1;
            }
        }

        public string Title
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                this.title_text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(titleTextId)));
                return this.title_text.Text;
            }
        }

        [FindsBy(How = How.Id, Using = titleTextId)]
        public IWebElement title_text { get; private set; }
        internal void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        internal void Save()
        {
            this.saveButton.Click();
        }

        internal void SaveAndWaitForTitle()
        {
            this.saveButton.Click();
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(titleTextId)));
        }

        internal void SetTitle(string title)
        {
            this.title.Clear();
            this.title.SendKeys(title);
        }
    }
}