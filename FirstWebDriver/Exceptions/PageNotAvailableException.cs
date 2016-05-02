using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstWebDriver.Exceptions
{
    public class PageNotAvailableException : Exception
    {
        public PageNotAvailableException(string pageName) : base("Page not found: " + pageName) { }
    }
}
