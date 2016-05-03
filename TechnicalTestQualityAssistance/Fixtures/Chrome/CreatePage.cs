using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    class CreatePage : Fixtures.CreatePage
    {
        public CreatePage() : base(DriverProvider.New<ChromeDriver>()) { }
    }
}
