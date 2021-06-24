using Common.PageObject.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Common
{
    public class HomeGestorPO : BasePage
    {
        public HomeGestorPO(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string MensagemLogin => driver.FindElement(MANEGER_HOME_PAGE.byLoginMessage).Text;

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://hlg-painel.styllus.online/#/pages/login");
        }
    }
}
