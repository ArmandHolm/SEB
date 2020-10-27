using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace SEB.Tests
{
    [TestFixture]
    public class TestBase
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = CreateChrome();
            driver.Manage().Window.Maximize();
        }

        private IWebDriver CreateChrome()
        {
            var options = new ChromeOptions();
            //options.AddArguments("--headless", "--window-size=1920,1080", "--no-sandbox");
            return new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options, TimeSpan.FromSeconds(120));
        }


        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
