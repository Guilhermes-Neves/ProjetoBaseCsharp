using gestor.PageObjects;
using Gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class AjusteCashbackManualmenteSteps : IDisposable
    {
        IWebDriver driver;
        LoginGestorPO loginPO;
        RevendedoraGestorPO revendedoraPO;
        string url;

        public AjusteCashbackManualmenteSteps()
        {
            url = "http://localhost:8080/#/";
            driver = new ChromeDriver();
            revendedoraPO = new RevendedoraGestorPO(driver);
            loginPO = new LoginGestorPO(driver);
            loginPO.EfetuarLoginComDados(url, "pedro.albani@portalstyllus.com.br", "Styllus2020!@#");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }


        [Given(@"que edito uma revendedora")]
        public void DadoQueEditoUmaRevendedora()
        {
            revendedoraPO.Visitar();
            revendedoraPO.BuscarRevendedora("cpf", "000.029.017-30");
            revendedoraPO.EditarRevendedora();
        }
        
        [When(@"adiciono cashback para a mesma")]
        public void QuandoAdicionoCashbackParaAMesma()
        {
            revendedoraPO.AdicionarCashBack("500", "15122022");
        }

        [When(@"deleto o cashback")]
        public void QuandoDeletoOCashback()
        {
            revendedoraPO.DeletarCashback();
        }


        [Then(@"vejo a mensagem de sucesso ""(.*)""")]
        public void EntaoVejoAMensagemDeSucesso(string mensagem)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            bool iguais = wait.Until(drv => revendedoraPO.MensagemSucesso == mensagem);
            Assert.True(iguais);

            driver.Quit();
        }


    }
}
