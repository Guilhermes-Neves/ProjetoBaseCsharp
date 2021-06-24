using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarLoginSucesso : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.PreencherFormulario(usuarioGestor, senhaGestor);
            loginGestorPO.SubmeterFormulario();

            //Assert.AreEqual("A combinação de usuário e senha não foi identificada. Por favor, verefique os dados informados.", homeGestorPO.MensagemLogin);
        }
    }
}