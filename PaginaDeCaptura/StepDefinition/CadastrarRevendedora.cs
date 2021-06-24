using NUnit.Framework;
using PaginaCaptura.Commons;

namespace PaginaDeCaptura.StepDefinition
{
    [TestFixture]
    public class CadastrarRevendedora : BaseTest
    {
        [Test()]
        [Theory]
        public void Test()
        {
           
            capturaPO.Visitar();
            capturaPO.PreencherDadosPessoais(nome, telefone, "");
            capturaPO.PreencherCpfEDataNascimento(cpf, nascimento);
            Assert.AreEqual("Parabéns! Você terminou seu cadastro!", capturaPO.TituloMensagem);
            Assert.AreEqual("Acesse seu escritório virtual, uma área exclusiva onde você poderá escolher seus produtos, solicitar crédito para pagar seus pedidos com boleto para 30 dias, receber bônus para escolher novas peças e muito mais!", capturaPO.ConteudoMensagem);
        }
    }
}
