using Gestor.Commons;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gestor
{
    [TestFixture]
    public class ValidarPedidosComStatusCancelado : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            pedidosEscritorioPO.Visitar();

            pedidosEscritorioPO.AplicarFiltro("CANCELADO", "", "status");

            //Assert.IsTrue(pedidosEscritorioPO.EncontrarBotao());
        }
    }
}