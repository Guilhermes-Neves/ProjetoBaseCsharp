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
        private By byDangerMessage;
        private By byLimiteCredito;

        public string MensagemLogin => driver.FindElement(byDangerMessage).Text;

        public string LimiteDeCredito => driver.FindElement(byLimiteCredito).Text;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            bySpanUsuario = By.CssSelector(".media.media-pill");
            byDangerMessage = By.CssSelector("p.vn-message");
            byLimiteCredito = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div[1]/div/div/div[1]/div[1]/span");
        }

        private By MensagemInicial()
        {
            return By.CssSelector(".h3.text-white");
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public Boolean EsperarCarregamento()
        {
            if (Esperar().Until(ExpectedConditions.ElementIsVisible(byLimiteCredito)).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
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


    }
}
