﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace TechnicalTestQualityAssistance.Drivers
{
    static class DriverProvider
    {
        public static IWebDriver New<T>()  where T : IWebDriver, new()
        {
            var t = typeof(T);
            if (t == typeof(ChromeDriver))
            {
                var options = new ChromeOptions();
                options.AddArgument("--disable-extensions");
                return new ChromeDriver(options);
            }
            else
            {
                return new T();
            }
        }
    }
}