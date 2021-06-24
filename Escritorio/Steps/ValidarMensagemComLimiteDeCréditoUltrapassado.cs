using Escritorio.Commons;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Escritorio
{
    [TestFixture]
    public class ValidarMensagemComLimiteDeCréditoUltrapassado : BaseTest
    {
        [Test()]
        public void Test()
        {
            //definir produtos para o teste
            List<Produtos> listaProdutos = produtos.RetornarProdutosUltrapassandoLimiteCredito();

            loginPO.EfetuarLoginComDados(usuarioEscritorio, senhaEscritorio);
            homePO.VerficiarExtratoLimiteCredito();
            limiteCreditoTexto = homePO.LimiteDeCredito.Substring(3);
            limiteCreditoTextoCompleto = homePO.LimiteDeCredito;
            limiteCredito = decimal.Parse(limiteCreditoTexto);

            produtosPO.Visitar();

            foreach (var p in listaProdutos)
            {
                produtosPO.PesquisarPorRef(p.Referencia, 30);
                produtosPO.AdicionarProdutos(p.Quantidade, 30);
            }

            carrinhoPO.Visitar();
            subTotal = decimal.Parse(carrinhoPO.Subtotal);
            //.Substring(12)
            int quantidade = Int32.Parse(listaProdutos[0].Quantidade) + 10;

            while (subTotal < limiteCredito)
            {
                carrinhoPO.AlterarQuantidade(quantidade.ToString());
                quantidade += 10;
                subTotal = decimal.Parse(carrinhoPO.Subtotal);
            }

            Assert.False(carrinhoPO.ValidarFormaPagamentoPrazo());
            //Assert.AreEqual($"Seu limite atual para compras no boleto é de: {limiteCreditoTextoCompleto}", carrinhoPO.AlertaLimitePedido);

        }
    }
}
