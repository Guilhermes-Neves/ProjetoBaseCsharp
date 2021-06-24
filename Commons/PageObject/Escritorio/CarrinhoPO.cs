using OpenQA.Selenium;
using Commons.PageObject.Common;
using Commons.Core;
using System;

namespace Commons
{
    public class CarrinhoPO : BasePage
    {
        public CarrinhoPO(WebDriver driver)
        {
            this.driver = driver;

        }

        public string AlertaLimitePedido => driver.GetText(OFFICE_CART_PAGE.byAlertaLimiteCredito, 30);

        public string TabelaDeProdutos => driver.GetText(OFFICE_CART_PAGE.byTable, 30);

        public string Subtotal => driver.GetText(OFFICE_CART_PAGE.bySubtotal, 30).Substring(12);

        public string Desconto => driver.FindElement(OFFICE_CART_PAGE.byDesconto).Text;

        public string Total => driver.FindElement(OFFICE_CART_PAGE.byTotal).Text;

        public bool BotaoDesativado => driver.FindElement(OFFICE_CART_PAGE.byBotaoFinalizarPedido).Enabled;

        public string DescontoItem => driver.FindElement(OFFICE_CART_PAGE.byTdDesconto).Text;

        public bool EstoqueIndisponivel(string mensagem)
        {
            string mensagemDesejada = driver.GetText(OFFICE_CART_PAGE.byAlertaSemEstoque, 30);

            if (mensagem == mensagemDesejada)
            {
                return true;
            }

            return false;
        }

        public bool ValidarAlertaTotalPedido(string mensagem, int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            driver.WaitUntilElementDesappear(BASE_PAGE.byLoadProducts, 10);

            while (DateTime.Now <= timeoutLimit)
            {
                string mensagemTotalPedido = driver.GetText(OFFICE_CART_PAGE.byAlertaTotalPedido, 30);
                if (mensagemTotalPedido == mensagem)
                {
                    return true;
                }
            }

            return false;
        }    


        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_ESCRITORIO + "pedidos/carrinho");
        }


        public void AlterarQuantidade(string quantidade)
        {
            driver.SendKey(OFFICE_CART_PAGE.byInputQuantidade, quantidade, 10);
            AguardarCarregamentoPagina();
            driver.OnClick(OFFICE_CART_PAGE.bySubtotal, 10);
        }

        public void SelecionarPagamento(string formaPagamento)
        {
            driver.SelectText(OFFICE_CART_PAGE.bySelectPagamento, formaPagamento, 10);
        }

        public void SelecionarFrete(string frete)
        {
            if (frete == "Entrega Normal")
            {
                driver.OnClick(OFFICE_CART_PAGE.byCheckEntregaNormal, 5);
            }
            if (frete == "Entrega Rápida")
            {
                driver.OnClick(OFFICE_CART_PAGE.byCheckEntregaRapida, 5);
            }
            if (frete == "Frete Gratis")
            {

            }
        }

        public void AplicarCashback(string valor)
        {
            driver.SendKey(OFFICE_CART_PAGE.byInputCashback, valor, 30);
            driver.OnClick(OFFICE_CART_PAGE.byBotaoAplicarCashback, 30);
        }

        public void FinalizarPedido()
        {
            driver.OnClick(OFFICE_CART_PAGE.byBotaoFinalizarPedido, 5);
        }

        public bool ValidarProdutosNoCarrinho(string campoDesejado, string valorDesejado)
        {
            driver.WaitUntilElementDesappear(BASE_PAGE.byLoadProducts, 10);
            int qtdProdutosCarinho = driver.GetElementCount($"li.{campoDesejado}", 30);

            for (int i = 1; i <= qtdProdutosCarinho; i++)
            {
                By elemento = By.XPath($"(//li[@class='{campoDesejado}'])[{i}]");
                string valorEncontrado = driver.GetText(elemento, 30);

                if (valorEncontrado == valorDesejado)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidarFormaPagamentoPrazo()
        {
            driver.OnClick(OFFICE_CART_PAGE.bySelectPagamento, 30);
            return driver.IsElementDisplayed(OFFICE_CART_PAGE.byOptionPagamentoPrazo);
        }
    }
}
