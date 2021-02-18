using Common;
using Common.PageObject;
using Common.PageObject.Gestor;
using gestor.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Gestor.StepDefinition
{
    [Binding]
    public class PedidosSteps : IDisposable
    {

        IWebDriver driver;
        LoginGestorPO loginPO;
        Utilitarios util;
        PedidosEcritorioPO pedidosEscritorioPO;
        PedidosCapturaPO pedidosCapturaPO;
        string url;

        public PedidosSteps()
        {
            driver = new ChromeDriver();
            util = new Utilitarios(driver);
            pedidosEscritorioPO = new PedidosEcritorioPO(driver);
            pedidosCapturaPO = new PedidosCapturaPO(driver);
            loginPO = new LoginGestorPO(driver);
            url = util.GetUrl("gestor");
            loginPO.EfetuarLoginComDados(url, util.UsuarioLogin("gestor"), util.SenhaLogin("gestor"));
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Given(@"que estou na página de pedidos da página de captura")]
        public void DadoQueEstouNaPaginaDePedidosDaPaginaDeCaptura()
        {
            pedidosCapturaPO.Visitar();
        }

        [Given(@"que eu estou na página de pedidos do escritório")]
        public void DadoQueEuEstouNaPaginaDePedidosDoEscritorio()
        {
            pedidosEscritorioPO.Visitar();
        }

        [When(@"eu aplico o filtro ""(.*)"" e ""(.*)"" no ""(.*)""")]
        public void QuandoEuAplicoOFiltroENo(string valor1, string valor2, string campo)
        {
            pedidosEscritorioPO.pedidos.AplicarFiltro(valor1, valor2, campo);
        }

        [Then(@"eu visualizo pedidos com o ""(.*)"" no ""(.*)""")]
        public void EntaoEuVisualizoPedidosComONo(string valor, string campo)
        {
            string pedidoEncontrado = pedidosEscritorioPO.pedidos.EncontrarPedido(campo);
            valor = valor.Replace("NCEIÇÃO", "...");
            Assert.AreEqual(valor, pedidoEncontrado);
        }
    }
}
