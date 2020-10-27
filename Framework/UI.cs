using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SEB.Tests
{
    class UI
    {
        public static IWebElement ScrollToElement(IWebDriver driver, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                    var elem = element;
                if (elem.Location.Y > 200)
                {
                    js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
                }
                return element;
            }
                catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetText(IWebElement element)
        {
            for (int i = 0; i < 5; i++)
            try
            {
                return element.Text;
            }

            catch (StaleElementReferenceException) { }
            return null;
        }

        public static void ClickElement(IWebDriver driver, By locator)
        {
            Exception lastException = null;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    WaitForElementVisible(driver, locator);
                    driver.FindElement(locator).Click();
                    break;
                }
                catch (Exception e)
                {
                    lastException = e;
                }
            }

            if (lastException is WebDriverTimeoutException)
            {
                throw lastException;
            }
        }

        public static void WaitForPageToLoad(IWebDriver drv)
        {
            IJavaScriptExecutor jsExec = (IJavaScriptExecutor)drv;
            WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(drv, Configuration.DefaultElementStatusCheckTimeout);

            bool jQueryDefined = (bool)jsExec.ExecuteScript("return typeof jQuery != 'undefined'");
            if (jQueryDefined)
            {
                Thread.Sleep(Configuration.DefaultPageLoadCheckStabilizationTimeout);

                wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return (typeof jQuery !== 'undefined') && jQuery.active == 0"));

                wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return document.readyState").ToString().Equals("complete"));

                Thread.Sleep(Configuration.DefaultPageLoadCheckStabilizationTimeout);
            }
        }

        public static void WaitForElementVisible(IWebDriver drv, By by)
        {
            WebDriverWait wait = new WebDriverWait(drv, Configuration.DefaultElementStatusCheckTimeout);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public static void NavigateTo(IWebDriver driver, string url)
        {
            if (!url.StartsWith("https://"))
            {
                url = "https://" + url;
                driver.Navigate().GoToUrl(url);
            }
        }
    }
}
