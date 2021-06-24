using Escritorio.Commons;
using NUnit.Framework;
using System.Collections.Generic;

namespace Escritorio
{
    [TestFixture]
    public class ValidarMensagemPedido : BaseTest
    {
        [Test()]
        public void Test()
        {
            //definir produtos para o teste
            List<Produtos> listaProdutos = produtos.RetornarProdutosValorAte100();

            loginPO.EfetuarLoginComDados(usuarioEscritorio, senhaEscritorio);
            produtosPO.Visitar();

            foreach (var p in listaProdutos)
            {
                produtosPO.PesquisarPorRef(p.Referencia, 30);
                produtosPO.AdicionarProdutos(p.Quantidade, 30);
            }

            carrinhoPO.Visitar();
            carrinhoPO.AguardarCarregamentoPagina();
            Assert.True(carrinhoPO.ValidarAlertaTotalPedido("Atenção Para efetuar um pedido, selecione pelo menos R$ 100,00 em produtos", 10));
        }
    }
}
