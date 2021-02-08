using OpenQA.Selenium;
using Escritorio.Helpers;
using Common;

namespace escritorio.PageObjects
{
    public class LoginPO
    {
        IWebDriver driver;
        private By byInputLogin;
        private By byInputPassword;
        private By byBotaoLogin;
        Utilitarios util;
        
    
        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("input-email");
            byInputPassword = By.Id("input-password");
            byBotaoLogin = By.ClassName("btn-primary");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            util = new Utilitarios(driver);
        }

       public void Visitar(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherFormulario(string codStyllus, string password)
        {
            util.SendKey(byInputLogin, codStyllus, 10);
            util.SendKey(byInputPassword, password, 10);
        }

        public void SubmeterFormulario()
        {
            util.OnClick(byBotaoLogin, 5);
        }

        public void EfetuarLoginComDados(string url ,string codStyllus, string password)
        {
            driver.Navigate().GoToUrl(url);
            util.SendKey(byInputLogin,codStyllus, 10);
            util.SendKey(byInputPassword,password, 10);
            util.OnClick(byBotaoLogin, 5);
        }


    }
}
