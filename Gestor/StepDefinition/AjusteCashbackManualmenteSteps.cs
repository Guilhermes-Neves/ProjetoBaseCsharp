using Common;
using gestor.PageObjects;
using Gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class AjusteCashbackManualmenteSteps : IDisposable
    {
        IWebDriver driver;
        LoginGestorPO loginPO;
        RevendedoraPO revendedoraPO;
        Utilitarios util;
        string url;

        public AjusteCashbackManualmenteSteps()
        {
            driver = new ChromeDriver();
            revendedoraPO = new RevendedoraPO(driver);
            loginPO = new LoginGestorPO(driver);
            util = new Utilitarios(driver);
            url = util.GetUrl("gestor");
            loginPO.EfetuarLoginComDados(url, util.UsuarioLogin("gestor"), util.SenhaLogin("gestor"));
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

        [When(@"altero o limite para a revendedora")]
        public void QuandoAlteroOLimiteParaARevendedora()
        {
            revendedoraPO.AjustarLimiteCredito("500");
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
