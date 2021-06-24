using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Common.PageObject.Common;

namespace Common
{
    public class CarrinhoPO : BasePage
    {
        Utilitarios util;

        public CarrinhoPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public string AlertaTotalPedido => util.GetText(OFFICE_CART_PAGE.byAlertaTotalPedido, 30);

        public string TabelaDeProdutos => util.GetText(OFFICE_CART_PAGE.byTable, 30);

        public string Subtotal => util.GetText(OFFICE_CART_PAGE.bySubtotal, 30);

        public string Desconto => driver.FindElement(OFFICE_CART_PAGE.byDesconto).Text;

        public string Total => driver.FindElement(OFFICE_CART_PAGE.byTotal).Text;

        public bool BotaoDesativado => driver.FindElement(OFFICE_CART_PAGE.byBotaoFinalizarPedido).Enabled;

        public string AlertaLimiteCredito => util.GetText(OFFICE_CART_PAGE.byAlertaLimite, 30);

        public string DescontoItem => driver.FindElement(OFFICE_CART_PAGE.byTdDesconto).Text;

        public string EstoqueIndisponivel => util.GetText(OFFICE_CART_PAGE.byAlertaSemEstoque, 30);

        public string Alerta(int alert)
        {
            switch (alert)
            {
                case 1:
                    string alertaLimite = util.GetText(OFFICE_CART_PAGE.byAlertaLimite, 30);
                    return alertaLimite;

                case 2:
                    string alertaEstoque = util.GetText(OFFICE_CART_PAGE.byAlertaEstoque, 30);
                    return alertaEstoque;

                case 3:
                    var alertaTotalPedido = util.GetText(OFFICE_CART_PAGE.byAlertaTotalPedido, 30);
                    return alertaTotalPedido;

                default:
                    return "erro";
            }
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl(URL_BASE_ESCRITORIO + "pedidos/carrinho");
        }

        public void EsperarCarregamento()
        {
            new WebDriverWait(driver, new TimeSpan(0, 0, 30))
                .Until(ExpectedConditions.ElementIsVisible(OFFICE_CART_PAGE.byTable));
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(1));
        }

        public void AlterarQuantidade(string quantidade)
        {
            util.ClearInput(OFFICE_CART_PAGE.byInputQuantidade, 10);
            util.SendKey(OFFICE_CART_PAGE.byInputQuantidade, quantidade, 10);
        }

        public void SelecionarPagamento(string formaPagamento)
        {
            util.SelectText(OFFICE_CART_PAGE.bySelectPagamento, formaPagamento, 10);
        }

        public void SelecionarFrete(string frete)
        {
            if (frete == "Entrega Normal")
            {
                util.OnClick(OFFICE_CART_PAGE.byCheckEntregaNormal, 5);
            }
            if (frete == "Entrega Rápida")
            {
                util.OnClick(OFFICE_CART_PAGE.byCheckEntregaRapida, 5);
            }
            if (frete == "Frete Gratis")
            {

            }
        }

        public void AplicarCashback(string valor)
        {
            util.SendKey(OFFICE_CART_PAGE.byInputCashback, valor, 30);
            util.OnClick(OFFICE_CART_PAGE.byBotaoAplicarCashback, 30);
        }

        public void FinalizarPedido()
        {
            util.OnClick(OFFICE_CART_PAGE.byBotaoFinalizarPedido, 5);
        }

        public bool ValidarProdutosNoCarrinho(string campoDesejado, string valorDesejado)
        {
            int qtdProdutosCarinho = util.GetElementCount($"(//li[contains(@class, '{campoDesejado}')])", 30);

            for (int i = 0; i <= qtdProdutosCarinho; i++)
            {
                By elemento = By.XPath($"(//li[contains(@class, '{campoDesejado}')])[{i}]");
                string valorEncontrado = util.GetText(elemento, 30);

                if (valorEncontrado == valorDesejado)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidarFormaPagamentoPrazo()
        {
            return util.IsElementDisplayed(OFFICE_CART_PAGE.byOptionPagamentoPrazo);
        }
    }
}
