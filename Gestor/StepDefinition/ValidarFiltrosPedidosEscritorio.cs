using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarFiltrosPedidosEscritorio : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            pedidosEscritorioPO.Visitar();

            string valorDesejado = "VITOR GIOVANNI DA CONCEIÇÃO";
            string campo = "nome";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "1396039";
            campo = "codStyllus";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "NOVO";
            campo = "status";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "502.60";
            campo = "valorMin";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "500", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "À Prazo";
            campo = "formaPag";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "11/02/2021";
            campo = "data";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);

            driver.Refresh();
            valorDesejado = "Estornado";
            campo = "statusPag";
            pedidosEscritorioPO.AplicarFiltro(valorDesejado, "", campo);
            Assert.AreEqual(valorDesejado, valorDesejado);
        }
    }
}