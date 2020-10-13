using System;
using TechTalk.SpecFlow;

namespace PaginaDeCaptura.StepDefinition
{
    [Binding]
    public class CadastrarUmaRevendedoraSteps
    {
        [Given(@"que acesso a página de captura")]
        public void DadoQueAcessoAPaginaDeCaptura()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"faço o cadastro da revendedora")]
        public void QuandoFacoOCadastroDaRevendedora()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"seleciono o kit de entrada")]
        public void QuandoSelecionoOKitDeEntrada()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"seleciono para receber no primeiro pedido")]
        public void QuandoSelecionoParaReceberNoPrimeiroPedido()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"efetuo pagamento com cartão")]
        public void QuandoEfetuoPagamentoComCartao()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"vejo a mensagem (.*)")]
        public void EntaoVejoAMensagem(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
