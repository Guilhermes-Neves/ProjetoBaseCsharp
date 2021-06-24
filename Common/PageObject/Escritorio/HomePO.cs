using Common.PageObject.Common;
using OpenQA.Selenium;
using System;

namespace Common
{
    public class HomePO : BasePage
    {
        Utilitarios util;

        public bool ValidarMensagemLogin(string mensagem,int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit)
            {
                string mensagemLogin = util.GetText(OFFICE_HOME_PAGE.byDangerMessage, 30);

                if (mensagemLogin == mensagem)
                {
                    return true;
                }
            }

            return false;
        }

        public string LimiteDeCredito => util.GetText(OFFICE_HOME_PAGE.byLimiteCredito, 30);

        public HomePO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl(URL_BASE_ESCRITORIO);
        }


    }
}
