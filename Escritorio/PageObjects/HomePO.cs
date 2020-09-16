using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace escritorio.PageObjects
{
    public class HomePO
    {

        private IWebDriver driver;
        private By bySpanUsuario;
        private By bySpanSair;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            bySpanUsuario = By.CssSelector(".media.media-pill");
            bySpanSair = By.CssSelector("a[href='#!']");
        }

        private By MensagemInicial()
        {
            return By.CssSelector(".h3.text-white");
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public Boolean ValidarLogin()
        {
            if (Esperar().Until(ExpectedConditions.ElementIsVisible(MensagemInicial())).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online/#/");
        }

        public void EfetuarLogOut()
        {
            driver.FindElement(bySpanUsuario).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("document.querySelector(\"'a[href=\'#!\']\"').click();");
        }

    }
}
