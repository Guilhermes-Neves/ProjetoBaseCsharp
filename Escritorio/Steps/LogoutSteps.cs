using escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Escritorio.Steps
{
    [Binding]
    public class LogoutSteps
    {
        string url = "https://hlg-escritorio.styllus.online/";
        IWebDriver driver;
        LoginPO loginPO;
        HomePO homePO;

        [Given(@"que estou logado")]
        public void DadoQueEstouLogado()
        {
            driver = Helpers.Helpers.IniciarDriver(driver);
            homePO = new HomePO(driver);
            loginPO = new LoginPO(driver);

            loginPO.EfetuarLoginComDados("1590", "Jesco1986");
        }

        [When(@"realizo o logout")]
        public void QuandoRealizoOLogout()
        {
            homePO.EfetuarLogOut();
        }

        [Then(@"vejo a página de login")]
        public void EntaoVejoAPaginaDeLogin()
        {
            loginPO.ValidarLogout();
            Helpers.Helpers.FinalizarDriver(driver);
        }
    }
        

}
