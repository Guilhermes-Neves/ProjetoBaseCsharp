using Escritorio.Commons;
using NUnit.Framework;

namespace Escritorio
{
    [TestFixture]
    public class ValidarLoginSucesso : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginPO.Visitar();
            loginPO.PreencherFormulario(usuarioEscritorio, senhaEscritorio);
            driver.GetScreenshot();
            loginPO.SubmeterFormulario();

            Assert.True(homePO.ValidarMensagemLogin("Bem vindo ;)", 30));
            driver.GetScreenshot();
        }
    }
}
