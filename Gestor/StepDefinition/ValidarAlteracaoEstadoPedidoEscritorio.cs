using Gestor.Commons;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gestor
{
    [TestFixture]
    public class ValidarAlteracaoEstadoPedidoEscritorio : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            pedidosEscritorioPO.Visitar();

            pedidosEscritorioPO.AplicarFiltro("NOVO", "", "status");
            pedidosEscritorioPO.AlterarEstadoPedido("CANCELADO");

            //bool iguais = wait.Until(drv => revendedoraPO.MensagemSucesso == "Estado do pedido alterado com sucesso :D");
            //Assert.True(iguais);
        }
    }
}