﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace TechnicalTestQualityAssistance.Fixtures.Firefox
{
    class CreatePage : Fixtures.CreatePage
    {
        public CreatePage() : base(new FirefoxDriver()) { }
    }
}
