using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Chrome;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions() : base(new ChromeDriver()) { }
    }
}
