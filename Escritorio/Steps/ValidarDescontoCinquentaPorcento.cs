using Escritorio.Commons;
using NUnit.Framework;
using System.Collections.Generic;

namespace Escritorio
{
    [TestFixture]
    public class ValidarDescontoCinquentaPorcento : BaseTest
    {
        [Test()]
        public void Test()
        {
            //definir produtos para o teste
            List<Produtos> listaProdutos = produtos.RetornarProdutosValorMaior800();

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

            foreach (var p in listaProdutos)
            {
                driver.GetScreenshot();
                Assert.IsTrue(carrinhoPO.ValidarProdutosNoCarrinho("subtitulo", p.Referencia));
                Assert.IsTrue(carrinhoPO.ValidarProdutosNoCarrinho("tamanho", $"Tamanho: {p.Tamanho}"));
                Assert.IsTrue(carrinhoPO.ValidarProdutosNoCarrinho("cor", $"Cor: {p.Cor}"));
                Assert.IsTrue(carrinhoPO.ValidarProdutosNoCarrinho("desconto", $"Desconto: {produtos.ValidarDesconto(p, decimal.Parse(carrinhoPO.Subtotal))}"));
            }

        }
    }
}
