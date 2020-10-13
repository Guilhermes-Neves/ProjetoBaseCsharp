using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace Escritorio.Helpers
{
    public static class Helpers
    {
       
        [SetUp]
        public static IWebDriver IniciarDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return driver;
        }

        [TearDown]
        public static void FinalizarDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
