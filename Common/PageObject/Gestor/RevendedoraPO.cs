using OpenQA.Selenium;
using System.Threading;
using Common.PageObject.Common;

namespace Common
{
    public class RevendedoraPO : BasePage
    {
        Utilitarios util;

        public RevendedoraPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public string MensagemSucesso => driver.FindElement(MANEGER_RESELLER_PAGE.byMensagemSucesso).Text;
        public string CpfRevendedoraTabela => driver.FindElement(MANEGER_RESELLER_PAGE.byTdCpf).Text;
        public string CodStyllusRevendedoraTabela => driver.FindElement(MANEGER_RESELLER_PAGE.byTdCod).Text;
        public string TabelaRevendedoras => driver.FindElement(MANEGER_RESELLER_PAGE.byTable).Text;

        public void Visitar()
        {
            util.OnClick(MANEGER_RESELLER_PAGE.byLinkRevendedoras, 10);
        }

        public void FiltrarRevendedora(string cpf)
        {
            util.SendKey(MANEGER_RESELLER_PAGE.byInputCpf, cpf, 10);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoBuscar, 10);
        }

        public void EditarRevendedora()
        {
            util.OnClick(MANEGER_RESELLER_PAGE.byEditarRevendedora, 10);
        }

        public void AdicionarCashBack(string valor, string data)
        {
            util.OnClick(MANEGER_RESELLER_PAGE.byTabCashBack, 30);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoAdicionarCashback, 30);
            util.SendKey(MANEGER_RESELLER_PAGE.byInputValorCashback, valor, 30);
            util.SendKey(MANEGER_RESELLER_PAGE.byInputDataCashback, data, 30);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoSalvar, 30);
        }

        public void AjustarLimiteCredito(string novoLimite)
        {
            util.OnClick(MANEGER_RESELLER_PAGE.byTabCredit, 30);
            util.OnClick(MANEGER_RESELLER_PAGE.byAddCredit, 30);
            util.SendKey(MANEGER_RESELLER_PAGE.byNovoLimite, novoLimite, 30);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoSalvarLimite, 30);
        }

        public void DeletarCashback()
        {
            util.OnClick(MANEGER_RESELLER_PAGE.byTabCashBack, 10);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoDeletar, 10);
            util.OnClick(MANEGER_RESELLER_PAGE.byBotaoProssiga, 10);
        }

        public string EncontrarRevendedora(string field)
        {
            switch (field)
            {
                case "nome":
                    string nome = util.GetText(MANEGER_RESELLER_PAGE.byTdName, 30);
                    return nome;

                case "cpf":
                    string cpf = util.GetText(MANEGER_RESELLER_PAGE.byTdCpf, 30); 
                    return cpf;

                case "codStyllus":
                    string cod = util.GetText(MANEGER_RESELLER_PAGE.byTdCod, 30); 
                    return cod; 
                
                default:
                    return "não encontrou";
            }
        }

        public void BuscarRevendedora(string value, string field)
        {
            switch (field)
            {
                case "nome":
                    util.SendKey(MANEGER_RESELLER_PAGE.byInputNome, value, 10);
                    util.OnClick(MANEGER_RESELLER_PAGE.byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                case "cpf":
                    util.SendKey(MANEGER_RESELLER_PAGE.byInputCpf, value, 10);
                    util.OnClick(MANEGER_RESELLER_PAGE.byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                case "codStyllus":
                    util.SendKey(MANEGER_RESELLER_PAGE.byInputCodStyllus, value, 10);
                    util.OnClick(MANEGER_RESELLER_PAGE.byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                default:
                    break;
            }
        }


    }
}
