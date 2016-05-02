using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions() : base(new FirefoxDriver()) { }
    }
}
