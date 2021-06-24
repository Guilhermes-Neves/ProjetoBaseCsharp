using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarDelecaoCashback : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            revendedoraPO.Visitar();
            revendedoraPO.BuscarRevendedora("cpf", cpfRevendedora);
            revendedoraPO.EditarRevendedora();
            revendedoraPO.DeletarCashback();

            Assert.AreEqual("Operação realizada com sucesso", revendedoraPO.MensagemSucesso);
        }
    }
}