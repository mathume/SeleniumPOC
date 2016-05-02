using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TechnicalTestQualityAssistance.Fixtures.Chrome
{
    class Login : Fixtures.Login
    {
        public Login() : base(new ChromeDriver()) { }
    }
}
