using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escritorio.Helpers
{
    public static class Helpers
    {
        [SetUp]
        public static IWebDriver IniciarDriver(IWebDriver driver)
        {
            var Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        [TearDown]
        public static void FinalizarDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
