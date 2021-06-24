using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarAdicaoCashback : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            revendedoraPO.Visitar();
            revendedoraPO.BuscarRevendedora("cpf", cpfRevendedora);
            revendedoraPO.EditarRevendedora();
            revendedoraPO.AdicionarCashBack("500", "15122022");

            Assert.AreEqual("Operação realizada com sucesso", revendedoraPO.MensagemSucesso);
        }
    }
}