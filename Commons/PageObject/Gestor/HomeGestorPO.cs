using Commons.Core;
using Commons.PageObject.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Commons
{
    public class HomeGestorPO : BasePage
    {
        public HomeGestorPO(WebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidarMensagemLogin(string mensagem, int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit)
            {
                string mensagemLogin = driver.GetText(MANEGER_HOME_PAGE.byLoginMessage, 30);

                if (mensagemLogin == mensagem)
                {
                    return true;
                }
            }

            return false;
        }

        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_GESTOR);
        }
    }
}
