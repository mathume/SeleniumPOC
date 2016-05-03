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

        [FindsBy(How = How.Id, Using = titleId)]
        public IWebElement title_text { get; private set; }

        private const string titleId = "title-text";

        public string Title
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                this.title_text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(titleId)));
                return this.title_text.Text;
            }
        }

        [FindsBy(How = How.Id, Using = "rte-button-publish")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "editPageLink")]
        private IWebElement editButton;

        public bool CanEdit
        {
            get
            {
                return this.driver.FindElements(By.Id("editPageLink")).Count == 0;
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

        internal void Navigate(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

    }
}
