using Gestor.Commons;
using NUnit.Framework;

namespace Gestor
{
    [TestFixture]
    public class ValidarLoginFalha : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginGestorPO.Visitar();
            loginGestorPO.PreencherFormulario("pedro.albani@portalstyllus.com", "Styllus20");
            driver.GetScreenshot();
            loginGestorPO.SubmeterFormulario();

            Assert.True(homeGestorPO.ValidarMensagemLogin("Credenciais inválidas!", 5));
            driver.GetScreenshot();
        }
    }
}