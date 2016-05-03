using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class Page : PageObjectForFactory
    {
        public Page(IWebDriver driver) : base(driver) 
        {
            this.ActionMenu = PageFactory.InitElements<PageActionMenu>(this.driver);
        }

        [FindsBy(How = How.Id, Using = "content-title")]
        private IWebElement title;

        [FindsBy(How = How.Id, Using = titleTextId)]
        public IWebElement title_text { get; private set; }

        private const string titleTextId = "title-text";

        public string Title
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                this.title_text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(titleTextId)));
                return this.title_text.Text;
            }
        }

        [FindsBy(How = How.Id, Using = "rte-button-publish")]
        private IWebElement saveButton;

        private const string editButtonId = "editPageLink";

        [FindsBy(How = How.Id, Using = editButtonId)]
        private IWebElement editButton;

        public bool CanEdit
        {
            get
            {
                return this.driver.FindElements(By.Id("editButtonId")).Count() == 1;
            }
        }

        public PageActionMenu ActionMenu { get; private set; }

        internal void SetTitle(string title)
        {
            this.title.Clear();
            this.title.SendKeys(title);
        }

        internal void Save()
        {
            this.saveButton.Click();
            
            this.Add(this);
        }

        internal void SaveAndWaitForTitle()
        {
            this.saveButton.Click();
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(titleTextId)));
        }

        internal void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

    }
}
