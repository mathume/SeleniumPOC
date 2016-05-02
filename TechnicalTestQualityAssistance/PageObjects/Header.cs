using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class Header : PageObjectForFactory
    {
        public Header(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "quick-create-page-button")]
        private IWebElement quickCreatePageButton;

        public void Logout()
        {
            throw new NotImplementedException();
        }

        internal void CreatePage(string title)
        {
            quickCreatePageButton.Click();
            var page = PageFactory.InitElements<Page>(this.driver);
            
            page.SetTitle(title);
            page.Save();
            this.Add(page);
        }
    }
}
