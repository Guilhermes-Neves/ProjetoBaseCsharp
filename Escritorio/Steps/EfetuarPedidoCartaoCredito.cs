using Escritorio.Commons;
using NUnit.Framework;
using System.Collections.Generic;

namespace Escritorio
{
    [TestFixture]
    public class EfetuarPedidoCartaoCredito : BaseTest
    {
        [Test()]
        public void Test()
        {
            //definir produtos para o teste
            List<Produtos> listaProdutos = produtos.RetornarProdutosValorAte199();

            loginPO.EfetuarLoginComDados(usuarioEscritorio, senhaEscritorio);
            produtosPO.Visitar();

            foreach (var p in listaProdutos)
            {
                produtosPO.PesquisarPorRef(p.Referencia, 30);
                produtosPO.AdicionarProdutos(p.Quantidade, 30);
                driver.GetScreenshot();
                produtosPO.LimparFiltro();
            }

            carrinhoPO.Visitar();
            carrinhoPO.AguardarCarregamentoPagina();

            carrinhoPO.SelecionarPagamento("Cartão ou Boleto à vista");
            carrinhoPO.SelecionarFrete("Entrega Normal");
            carrinhoPO.FinalizarPedido();
            checkoutPO.FinalizarCheckoutCartao(numero, mes, ano, codigo);
            driver.GetScreenshot();

            carrinhoPO.AguardarCarregamentoPagina();
            Assert.True(checkoutPO.ValidarPedidoFinalizado("Pedido realizado com sucesso."));
            driver.GetScreenshot();

        }
    }
}
