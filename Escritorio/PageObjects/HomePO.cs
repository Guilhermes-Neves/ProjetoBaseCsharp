using Common;
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
        private By byDangerMessage;
        private By byLimiteCredito;
        Utilitarios util;

        public string MensagemLogin => util.GetText(byDangerMessage, 30);

        public string LimiteDeCredito => util.GetText(byLimiteCredito, 30);

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            byDangerMessage = By.CssSelector("p.vn-message");
            byLimiteCredito = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div[1]/div/div/div[1]/div[1]/span");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online/#/");
        }


    }
}
