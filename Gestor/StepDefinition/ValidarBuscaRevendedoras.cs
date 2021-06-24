using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarBuscaRevendedoras : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            revendedoraPO.Visitar();

            revendedoraPO.BuscarRevendedora("cpf", cpfRevendedora);
            Assert.AreEqual(cpfRevendedora, revendedoraPO.EncontrarRevendedora("cpf"));

            driver.Refresh();
            revendedoraPO.BuscarRevendedora("nome", nomeRevendedora);
            Assert.AreEqual(cpfRevendedora, revendedoraPO.EncontrarRevendedora("nome"));

            driver.Refresh();
            revendedoraPO.BuscarRevendedora("codStyllus", codStyllusRevendedora);
            Assert.AreEqual(cpfRevendedora, revendedoraPO.EncontrarRevendedora("nome"));
        }
    }
}