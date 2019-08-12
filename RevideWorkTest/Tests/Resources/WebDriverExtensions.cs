using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace RevideWorkTest.Tests.Resources
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this ISearchContext context, By by, uint timeout, bool displayed = false)
        {
            var wait = new DefaultWait<ISearchContext>(context);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(ctx =>
            {
                var element = ctx.FindElement(by);
                if (displayed && !element.Displayed)
                    return null;

                return element;
            });
        }
    }
}
