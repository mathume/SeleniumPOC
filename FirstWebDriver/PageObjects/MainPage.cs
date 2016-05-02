using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using FirstWebDriver.Exceptions;

namespace FirstWebDriver.PageObjects
{
    public class MainPage : PageObjectBase
    {
        [FindsBy(How = How.ClassName, Using = "MainPageBG")]
        private IWebElement BackGround;
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            this.PageName = "MainPage";
        }

        public string BackGroundText
        {
            get
            {
                return (string)this.Do(() =>
                    {
                        return this.BackGround.Text;
                    });
            }
        }
    }
}
