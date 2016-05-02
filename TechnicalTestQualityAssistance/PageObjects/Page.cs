using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TechnicalTestQualityAssistance.PageObjects
{
    internal class Page : PageObjectForFactory
    {
        public Page(IWebDriver driver) : base(driver) 
        {
            this.Menu = PageFactory.InitElements<PageActionMenu>(this.driver);
        }

        [FindsBy(How = How.Id, Using = "content-title")]
        private IWebElement title;

        [FindsBy(How = How.Id, Using = "title-text")]
        private IWebElement title_text;

        public string Title
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                this.title_text = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("title-text")));
                return this.title_text.Text;
            }
        }

        public IWebElement ConfirmButton
        {
            get
            {
                return this.confirmButton;
            }
        }

        [FindsBy(How = How.Id, Using = "rte-button-publish")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "confirm")]
        private IWebElement confirmButton;

        public PageActionMenu Menu { get; private set; }

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
    }
}
