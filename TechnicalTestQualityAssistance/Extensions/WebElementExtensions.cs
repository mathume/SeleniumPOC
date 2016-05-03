using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace TechnicalTestQualityAssistance.Extensions
{
    static class WebElementExtensions
    {
        public static void SendKeys(this IWebElement element, string keys, int times)
        {
            for (int i = 0; i < times; i++)
            {
                element.SendKeys(keys);
            }
        }
    }
}
