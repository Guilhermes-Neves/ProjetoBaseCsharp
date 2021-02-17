using Common;
using OpenQA.Selenium;

namespace gestor.PageObjects
{
    public class LoginGestorPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputPassword;
        private By byBotaoLogin;
        Utilitarios utilitarios;


        public LoginGestorPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.CssSelector("input[name='email']");
            byInputPassword = By.XPath("//*[@id='app']/div/main/div/div[2]/div/div/form/div[2]/input");
            byBotaoLogin = By.ClassName("login100-form-btn");
            utilitarios = new Utilitarios(driver);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public void Visitar(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherFormulario(string email, string password)
        {
            utilitarios.SendKey(byInputLogin, email, 10);
            utilitarios.SendKey(byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            utilitarios.OnClick(byBotaoLogin, 10);
        }

        public void EfetuarLoginComDados(string url, string email, string password)
        {
            driver.Navigate().GoToUrl(url);
            utilitarios.SendKey(byInputLogin, email, 10);
            utilitarios.SendKey(byInputPassword, password, 10);
            utilitarios.OnClick(byBotaoLogin, 10);
        }


    }
}
