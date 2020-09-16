using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace escritorio.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputPassword;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("input-email");
            byInputPassword = By.Id("input-password");
            byBotaoLogin = By.ClassName("btn-primary");
        }

        public void Visitar(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherFormulario(string codStyllus, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(codStyllus);
            driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBotaoLogin).Click();
        }

        public void EfetuarLoginComDados(string codStyllus, string password)
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online");
            driver.FindElement(byInputLogin).SendKeys(codStyllus);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byBotaoLogin).Click();
        }

        private By CampoLogin()
        {
            return byInputLogin;
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public Boolean ValidarLogout()
        {
            if (Esperar().Until(ExpectedConditions.ElementIsVisible(CampoLogin())).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
