using escritorio.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Escritorio.Spets
{
    [Binding]
    public class LoginSteps
    {

        string url = "https://hlg-escritorio.styllus.online/";
        IWebDriver driver;
        LoginPO loginPO;
        HomePO homePO;

        [Given(@"que visito a página inicial")]
        public void DadoQueVisitoAPaginaInicial()
        {
            //iniciando as classes
            driver = Helpers.Helpers.IniciarDriver(driver);
            homePO = new HomePO(driver);
            loginPO = new LoginPO(driver);

            //acessar o site
            loginPO.Visitar(url);
        }

        [When(@"preencho meus dados de acesso")]
        public void QuandoPreenchoMeusDadosDeAcesso()
        {
            loginPO.EfetuarLoginComDados("1590", "Jesco1986");
        }

        [Then(@"eu vejo a página incial")]
        public void EntaoEuVejoAPaginaIncial()
        {
            homePO.ValidarLogin();
            Helpers.Helpers.FinalizarDriver(driver);
        }
    }
}
