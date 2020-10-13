using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace PaginaDeCaptura.Helpers
{
    public class InitHelpers
    {
        [SetUp]
        public static IWebDriver IniciarDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
