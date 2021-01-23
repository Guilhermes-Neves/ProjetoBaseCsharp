using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace gestor.PageObjects
{
    public class HomeGestorPO
    {

        private IWebDriver driver;
        private By byLoginMessage;
        
        public string MensagemLogin => driver.FindElement(byLoginMessage).Text;

        public HomeGestorPO(IWebDriver driver)
        {
            this.driver = driver;
            byLoginMessage = By.CssSelector("p.toast-text");
        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


    }
}
