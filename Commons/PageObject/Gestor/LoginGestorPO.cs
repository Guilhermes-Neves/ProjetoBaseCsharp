using Common;
using Commons.Core;
using Commons.PageObject.Common;
using OpenQA.Selenium;

namespace Commons
{
    public class LoginGestorPO : BasePage
    {
        public LoginGestorPO(WebDriver driver)
        {
            this.driver = driver;
        }

        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_GESTOR);
        }

        public void PreencherFormulario(string email, string password)
        {
            driver.SendKey(MANEGER_LOGIN_PAGE.byInputLogin, email, 10);
            driver.SendKey(MANEGER_LOGIN_PAGE.byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            driver.OnClick(MANEGER_LOGIN_PAGE.byBotaoLogin, 10);
        }

        public void EfetuarLoginComDados(string email, string password)
        {
            driver.NavigateTo(URL_BASE_GESTOR);
            driver.SendKey(MANEGER_LOGIN_PAGE.byInputLogin, email, 10);
            driver.SendKey(MANEGER_LOGIN_PAGE.byInputPassword, password, 10);
            driver.OnClick(MANEGER_LOGIN_PAGE.byBotaoLogin, 10);
        }


    }
}
