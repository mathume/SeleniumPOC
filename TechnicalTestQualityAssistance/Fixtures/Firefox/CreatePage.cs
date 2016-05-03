using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    class CreatePage : Fixtures.CreatePage
    {
        public CreatePage() : base(DriverProvider.New<FirefoxDriver>()) { }
    }
}
