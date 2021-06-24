using Commons.Core;
using Commons.PageObject.Common;
using System;

namespace Commons
{
    public class HomePO : BasePage
    {
        public HomePO(WebDriver driver)
        {
            this.driver = driver;
        }

        public bool ValidarMensagemLogin(string mensagem,int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit)
            {
                string mensagemLogin = driver.GetText(OFFICE_HOME_PAGE.byDangerMessage, 30);

                if (mensagemLogin == mensagem)
                {
                    return true;
                }
            }

            return false;
        }

        public void VerficiarExtratoLimiteCredito()
        {
            driver.OnClick(OFFICE_HOME_PAGE.byExtratoLimiteCredito, 30);
        }

        public string LimiteDeCredito => driver.GetText(OFFICE_HOME_PAGE.byLimiteCredito, 30);

        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_ESCRITORIO);
        }


    }
}
