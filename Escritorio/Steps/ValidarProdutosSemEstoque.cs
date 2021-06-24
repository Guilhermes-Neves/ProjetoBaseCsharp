using Escritorio.Commons;
using NUnit.Framework;
using System.Collections.Generic;

namespace Escritorio
{
    [TestFixture]
    public class ValidarProdutosSemEstoque : BaseTest
    {
        [Test()]
        public void Test()
        {
            //definir produtos para o teste
            List<Produtos> listaProdutos = produtos.RetornarProdutosSemEstoque();

            loginPO.EfetuarLoginComDados(usuarioEscritorio, senhaEscritorio);
            produtosPO.Visitar();

            produtosPO.AguardarCarregamentoPagina();
            produtosPO.PesquisarPorRef(listaProdutos[0].Referencia, 30);
            produtosPO.AcionarProdutoDesejadoModal();

            Assert.True(carrinhoPO.EstoqueIndisponivel("Estoque indisponível!"));

        }
    }
}
