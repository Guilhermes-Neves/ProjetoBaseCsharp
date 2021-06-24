using Common;
using Common.PageObject.Common;
using OpenQA.Selenium;

namespace Common
{
    public class LoginGestorPO : BasePage
    {
        Utilitarios utilitarios;
        
        public LoginGestorPO(IWebDriver driver)
        {
            this.driver = driver;
            utilitarios = new Utilitarios(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl(URL_BASE_GESTOR);
        }

        public void PreencherFormulario(string email, string password)
        {
            utilitarios.SendKey(MANEGER_LOGIN_PAGE.byInputLogin, email, 10);
            utilitarios.SendKey(MANEGER_LOGIN_PAGE.byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            utilitarios.OnClick(MANEGER_LOGIN_PAGE.byBotaoLogin, 10);
        }

        public void EfetuarLoginComDados(string email, string password)
        {
            driver.Navigate().GoToUrl(URL_BASE_GESTOR);
            utilitarios.SendKey(MANEGER_LOGIN_PAGE.byInputLogin, email, 10);
            utilitarios.SendKey(MANEGER_LOGIN_PAGE.byInputPassword, password, 10);
            utilitarios.OnClick(MANEGER_LOGIN_PAGE.byBotaoLogin, 10);
        }


    }
}
