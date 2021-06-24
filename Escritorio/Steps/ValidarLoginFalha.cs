using Escritorio.Commons;
using NUnit.Framework;

namespace Escritorio
{
    [TestFixture]
    public class ValidarLoginFalha : BaseTest
    {
        [Test()]
        public void Test()
        {
            loginPO.Visitar();
            loginPO.PreencherFormulario("13904656", "1444564");
            driver.GetScreenshot();
            loginPO.SubmeterFormulario();

            Assert.True(homePO.ValidarMensagemLogin("A combinação de usuário e senha não foi identificada. Por favor, verefique os dados informados.", 30));
            driver.GetScreenshot();
        }
    }
}
