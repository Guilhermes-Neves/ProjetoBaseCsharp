using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace gestor.PageObjects
{
    public class HomePO
    {

        private IWebDriver driver;
        private By byLoginMessage;
        
        public string MensagemLogin => driver.FindElement(byLoginMessage).Text;

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            byLoginMessage = By.CssSelector("p.toast-text");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://hlg-painel.styllus.online/#/pages/login");
        }


    }
}
