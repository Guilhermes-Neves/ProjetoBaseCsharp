using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarAlteracaoLimiteCredito : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.EfetuarLoginComDados(usuarioGestor, senhaGestor);
            revendedoraPO.Visitar();
            revendedoraPO.BuscarRevendedora("cpf", cpfRevendedora);
            revendedoraPO.EditarRevendedora();
            revendedoraPO.AjustarLimiteCredito("500");

            Assert.AreEqual("Operação realizada com sucesso", revendedoraPO.MensagemSucesso);
        }
    }
}