﻿using OpenQA.Selenium.Chrome;
using TechnicalTestQualityAssistance.Drivers;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    internal class SetRestrictions : Fixtures.SetRestrictions
    {
        public SetRestrictions()
            : base(DriverProvider.New<ChromeDriver>())
        {
        }
    }
}