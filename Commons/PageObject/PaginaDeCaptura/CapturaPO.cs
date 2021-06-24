using Commons.Core;
using Commons.PageObject.Common;

namespace Commons
{
    public class CapturaPO : BasePage
    {
        public CapturaPO(WebDriver driver)
        {
            this.driver = driver;
        }


        public string TituloMensagem => driver.FindElement(RESELLER_CATCH_PAGE.byTituloMensagem).Text;
        public string ConteudoMensagem => driver.FindElement(RESELLER_CATCH_PAGE.byConteudoMensagem).Text;

        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_CAPTURA + "meu-cadastro");
        }

        public void PreencherDadosPessoais(string nome, string telefone ,string codIndicador)
        {
            driver.SendKey(RESELLER_CATCH_PAGE.byInputNome, nome, 10);
            driver.SendKey(RESELLER_CATCH_PAGE.byInputTelefone, telefone, 10);
            driver.SendKey(RESELLER_CATCH_PAGE.byInputEmail, "teste@teste.com", 10);
            driver.SendKey(RESELLER_CATCH_PAGE.byInputIndicador, codIndicador, 10);
            driver.OnClick(RESELLER_CATCH_PAGE.byCheckTermos, 10);
            driver.OnClick(RESELLER_CATCH_PAGE.byBotaoAceitoTermos, 10);
            driver.OnClick(RESELLER_CATCH_PAGE.byBotaoContinuar, 10);

        }

        public void PreencherCpfEDataNascimento(string cpf, string data)
        {
            driver.SendKey(RESELLER_CATCH_PAGE.byInputCpf, cpf, 30);
            driver.SendKey(RESELLER_CATCH_PAGE.byInputData, data, 30);
        }

        public void FinalizarCadastro()
        {
            driver.OnClick(RESELLER_CATCH_PAGE.byBotaoFinalizarCadastro, 30);
        }

   

      

       
    }
}
