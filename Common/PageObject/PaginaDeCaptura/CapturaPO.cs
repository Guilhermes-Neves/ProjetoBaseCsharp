using Common.PageObject.Common;
using OpenQA.Selenium;

namespace Common
{
    public class CapturaPO : BasePage
    {
        Utilitarios util;

        public string TituloMensagem => driver.FindElement(RESELLER_CATCH_PAGE.byTituloMensagem).Text;
        public string ConteudoMensagem => driver.FindElement(RESELLER_CATCH_PAGE.byConteudoMensagem).Text;

        public CapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver); 
            
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl(URL_BASE_CAPTURA + "meu-cadastro");
        }

        public void PreencherDadosPessoais(string nome, string telefone ,string codIndicador)
        {
            util.SendKey(RESELLER_CATCH_PAGE.byInputNome, nome, 10);
            util.SendKey(RESELLER_CATCH_PAGE.byInputTelefone, telefone, 10);
            util.SendKey(RESELLER_CATCH_PAGE.byInputEmail, "teste@teste.com", 10);
            util.SendKey(RESELLER_CATCH_PAGE.byInputIndicador, codIndicador, 10);
            util.OnClick(RESELLER_CATCH_PAGE.byCheckTermos, 10);
            util.OnClick(RESELLER_CATCH_PAGE.byBotaoAceitoTermos, 10);
            util.OnClick(RESELLER_CATCH_PAGE.byBotaoContinuar, 10);

        }

        public void PreencherCpfEDataNascimento(string cpf, string data)
        {
            util.SendKey(RESELLER_CATCH_PAGE.byInputCpf, cpf, 30);
            util.SendKey(RESELLER_CATCH_PAGE.byInputData, data, 30);
        }

        public void FinalizarCadastro()
        {
            util.OnClick(RESELLER_CATCH_PAGE.byBotaoFinalizarCadastro, 30);
        }

   

      

       
    }
}
