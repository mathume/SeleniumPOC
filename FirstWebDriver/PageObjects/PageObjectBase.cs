using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstWebDriver.Exceptions;

namespace FirstWebDriver.PageObjects
{
    public abstract class PageObjectBase : IAvailablePage
    {
        private bool isAvailable = false;

        protected string PageName { get; set; }

        public bool IsAvailable
        {
            get
            {
                return this.isAvailable;
            }
            set
            {
                this.isAvailable = value;
            }
        }

        private void ThrowIfNotAvailable()
        {
            if (!this.IsAvailable)
            {
                throw new PageNotAvailableException(this.PageName);
            }
        }

        protected void Do(Action action)
        {
            this.ThrowIfNotAvailable();
            action();
        }

        protected object Do(Func<object> action)
        {
            this.ThrowIfNotAvailable();
            return action();
        }
    }
}
