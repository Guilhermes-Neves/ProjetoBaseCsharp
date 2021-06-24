using OpenQA.Selenium;
using Common.PageObject.Common;

namespace Common
{
    public class LoginPO : BasePage
    {
        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

       public void Visitar()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL_BASE_ESCRITORIO);
        }

        public void PreencherFormulario(string codStyllus, string password)
        {
            util.SendKey(OFFICE_LOGIN_PAGE.byInputLogin, codStyllus, 10);
            util.SendKey(OFFICE_LOGIN_PAGE.byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            util.OnClick(OFFICE_LOGIN_PAGE.byBotaoLogin, 5);
        }

        public void EfetuarLoginComDados(string codStyllus, string password)
        {
            Visitar();
            util.SendKey(OFFICE_LOGIN_PAGE.byInputLogin,codStyllus, 10);
            util.SendKey(OFFICE_LOGIN_PAGE.byInputPassword,password, 10);
            util.OnClick(OFFICE_LOGIN_PAGE.byBotaoLogin, 5);
        }


    }
}
