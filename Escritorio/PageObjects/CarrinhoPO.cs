using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Escritorio.Helpers;
using Common;

namespace escritorio.PageObjects
{
    public class CarrinhoPO
    {
        Utilitarios util;
        private IWebDriver driver;
        private By byTable;
        private By byAlertaTotalPedido;
        private By byInputQuantidade;
        private By bySubtotal;
        private By byDesconto;
        private By byTotal;
        private By byOptionPagamentoPrazo;
        private By bySelectPagamento;
        private By byCheckEntregaNormal;
        private By byCheckEntregaRapida;
        private By byBotaoFinalizarPedido;
        private By byAlertaLimite;
        private By byTdDesconto;
        private By byAlertaEstoque;
        private By byInputCashback;
        private By byBotaoAplicarCashback;

        public string AlertaTotalPedido => driver.FindElement(byAlertaTotalPedido).Text;
        public string TabelaDeProdutos => driver.FindElement(byTable).Text;
        public string Subtotal => driver.FindElement(bySubtotal).Text;
        public string Desconto => driver.FindElement(byDesconto).Text;
        public string Total => driver.FindElement(byTotal).Text;
        public bool BotaoDesativado => driver.FindElement(byBotaoFinalizarPedido).Enabled;
        public bool VerificarPagamentoFormaPrazo => Esperar().Until(ExpectedConditions.InvisibilityOfElementWithText(byOptionPagamentoPrazo, "À Prazo - Até 30 dias no boleto"));
        public string AlertaLimiteCredito => util.GetText(byAlertaLimite, 30);
        public string DescontoItem => driver.FindElement(byTdDesconto).Text;

        public CarrinhoPO(IWebDriver driver)
        {
            this.driver = driver;
            byTable = By.CssSelector("table tbody tr");
            byAlertaTotalPedido = By.CssSelector(".alert.alert-modern.alert-danger");
            bySubtotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[1]/strong");
            byDesconto = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[2]/strong");
            byTotal = By.XPath("//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]/strong");
            bySelectPagamento = By.Id("fr_pgto");
            byCheckEntregaNormal = By.XPath("//*[@id='app']/div/div/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[2]/div/p/span");
            byCheckEntregaRapida = By.XPath("//*[@id='app']/div/div/div/div/div[2]/div/div/div[2]/div[2]/div/div/div[3]/div/p/span");
            byBotaoFinalizarPedido = By.Id("place_order");
            byInputQuantidade = By.CssSelector("input.form-control.form-control-sm.text-center");
            byOptionPagamentoPrazo = By.XPath("//*[@id='fr_pgto']/option[2]");
            byAlertaLimite = By.CssSelector(".alert.alert-info");
            byTdDesconto = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[3]/table/tbody/tr/td[5]");
            byAlertaEstoque = By.CssSelector("p.alert.alert-danger");
            byInputCashback = By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/div/div[2]/div[1]/div/div/div/div/input");
            byBotaoAplicarCashback = By.CssSelector("button.btn.mt-2.btn-info.btn-block");
            util = new Utilitarios(driver);
        }

        public string Alerta(int alert)
        {
            switch (alert)
            {
                case 1:
                    string alertaLimite = util.GetText(byAlertaLimite, 30);
                    return alertaLimite;

                case 2:
                    string alertaEstoque = util.GetText(byAlertaEstoque, 30);
                    return alertaEstoque;

                case 3:
                    var alertaTotalPedido = util.GetText(byAlertaTotalPedido, 30);
                    return alertaTotalPedido;

                default:
                    return "erro";
            }
        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void EsperarCarregamento()
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 30))
                .Until(ExpectedConditions.ElementIsVisible(byTable));
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        public void AlterarQuantidade(string quantidade)
        {
            util.ClearInput(byInputQuantidade, 10);
            util.SendKey(byInputQuantidade, quantidade, 10);
        }

        public void SelecionarPagamento(string formaPagamento)
        {
            util.SelectText(bySelectPagamento, formaPagamento, 10);
        }

        public void SelecionarFrete(string frete)
        {
            if (frete == "Entrega Normal")
            {
                util.OnClick(byCheckEntregaNormal, 5);
            }
            if (frete == "Entrega Rápida")
            {
                util.OnClick(byCheckEntregaRapida, 5);
            }
            if (frete == "Frete Gratis")
            {

            }
        }

        public void AplicarCashback(string valor)
        {
            util.SendKey(byInputCashback, valor, 10);
            util.OnClick(byBotaoAplicarCashback, 5);
        }

        public void FinalizarPedido()
        {
            util.OnClick(byBotaoFinalizarPedido, 5);
        }



    }
}
