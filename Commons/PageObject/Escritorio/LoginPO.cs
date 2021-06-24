using OpenQA.Selenium;
using Commons.PageObject.Common;
using Commons.Core;

namespace Commons
{
    public class LoginPO : BasePage
    {
        public LoginPO(WebDriver driver)
        {
            this.driver = driver;
        }

       public void Visitar()
        {
            driver.NavigateTo(URL_BASE_ESCRITORIO);
        }

        public void PreencherFormulario(string codStyllus, string password)
        {
            driver.SendKey(OFFICE_LOGIN_PAGE.byInputLogin, codStyllus, 10);
            driver.SendKey(OFFICE_LOGIN_PAGE.byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            driver.OnClick(OFFICE_LOGIN_PAGE.byBotaoLogin, 5);
        }

        public void EfetuarLoginComDados(string codStyllus, string password)
        {
            Visitar();
            driver.SendKey(OFFICE_LOGIN_PAGE.byInputLogin,codStyllus, 10);
            driver.SendKey(OFFICE_LOGIN_PAGE.byInputPassword,password, 10);
            driver.OnClick(OFFICE_LOGIN_PAGE.byBotaoLogin, 5);
            AguardarCarregamentoPagina();
            AguardarCarregamentoPagina();
            AguardarCarregamentoPagina();
        }


    }
}
