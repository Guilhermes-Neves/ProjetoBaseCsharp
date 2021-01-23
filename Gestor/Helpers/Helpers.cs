using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace Escritorio.Helpers
{
    public class Helpers
    {

        [SetUp]
        public static IWebDriver IniciarDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
