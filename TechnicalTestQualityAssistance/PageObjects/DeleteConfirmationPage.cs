using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TechnicalTestQualityAssistance.PageObjects
{
    class DeleteConfirmationPage : Page
    {
        [FindsBy(How = How.Id, Using = "confirm")]
        private IWebElement confirmButton;

        public DeleteConfirmationPage(IWebDriver driver) : base(driver) { }

        public IWebElement ConfirmButton
        {
            get
            {
                return this.confirmButton;
            }
        }
    }
}
