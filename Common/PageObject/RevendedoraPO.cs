using OpenQA.Selenium;
using System.Threading;
using Common;

namespace Gestor.PageObjects
{
    public class RevendedoraPO
    {
        private IWebDriver driver;
        Utilitarios util;
        private By byInputCpf;
        private By byBotaoBuscar;
        private By byEditarRevendedora;
        private By byTabCashBack;
        private By byBotaoAdicionarCashback;
        private By byInputValorCashback;
        private By byInputDataCashback;
        private By byBotaoSalvar;
        private By byMensagemSucesso;
        private By byInputAccount;
        private By byLinkRevendedoras;
        private By byBotaoDeletar;
        private By byBotaoProssiga;
        private By byInputNome;
        private By byInputCodStyllus;
        private By byTable;
        private By byTdName;
        private By byTdCpf;
        private By byTdCod;
        private By byTabCredit;

        public RevendedoraPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            byInputNome = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[2]/div/div/div/input");
            byInputCpf = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[3]/div/div/div/input");
            byInputCodStyllus = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[4]/div/div/div/input");
            byBotaoBuscar = By.CssSelector("button.v-btn.primary");
            byLinkRevendedoras = By.XPath("/html/body/div[1]/div/nav/div[2]/div[2]/a[2]");
            byEditarRevendedora = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr/td[10]/a");
            byTabCashBack = By.XPath("/html/body/div[1]/div/main/div/div[2]/div/div/div/div/div[1]/div[2]/div/div[6]");
            byBotaoAdicionarCashback = By.CssSelector("button.indigo");
            byInputValorCashback = By.CssSelector("input[name='valor']");
            byInputDataCashback = By.CssSelector("input[name='expiresAt']");
            byBotaoSalvar = By.CssSelector("button.success--text");
            byMensagemSucesso = By.CssSelector("p.toast-text");
            byInputAccount = By.ClassName("mdi-account");
            byBotaoDeletar = By.CssSelector("button.error--text");
            byBotaoProssiga = By.XPath("/html/body/div/div[3]/div/div/div[3]/button[2]");
            byTable = By.CssSelector("table tbody tr");
            byTdName = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[1]");
            byTdCpf = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[4]");
            byTdCod = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr[1]/td[7]");
            byTabCredit = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div/div/div/div/div[1]/div[2]/div/div[7]");
        }

        public string MensagemSucesso => driver.FindElement(byMensagemSucesso).Text;
        public string CpfRevendedoraTabela => driver.FindElement(byTdCpf).Text;
        public string CodStyllusRevendedoraTabela => driver.FindElement(byTdCod).Text;
        public string TabelaRevendedoras => driver.FindElement(byTable).Text;

        public void Visitar()
        {
            util.OnClick(byLinkRevendedoras, 10);
        }

        public void FiltrarRevendedora(string cpf)
        {
            util.SendKey(byInputCpf, cpf, 10);
            util.OnClick(byBotaoBuscar, 10);
        }

        public void EditarRevendedora()
        {
            util.OnClick(byEditarRevendedora, 10);
        }

        public void AdicionarCashBack(string valor, string data)
        {
            util.OnClick(byTabCashBack, 30);
            util.OnClick(byBotaoAdicionarCashback, 30);
            util.SendKey(byInputValorCashback, valor, 30);
            util.SendKey(byInputDataCashback, data, 30);
            util.OnClick(byBotaoSalvar, 30);
        }

        public void DeletarCashback()
        {
            util.OnClick(byTabCashBack, 10);
            util.OnClick(byBotaoDeletar, 10);
            util.OnClick(byBotaoProssiga, 10);
        }

        public string EncontrarRevendedora(string field)
        {
            switch (field)
            {
                case "nome":
                    string nome = driver.FindElement(byTdName).Text;
                    return nome;

                case "cpf":
                    string cpf = driver.FindElement(byTdCpf).Text;
                    return cpf;

                case "codStyllus":
                    string cod = driver.FindElement(byTdCod).Text;
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
                    util.SendKey(byInputNome, value, 10);
                    util.OnClick(byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                case "cpf":
                    util.SendKey(byInputCpf, value, 10);
                    util.OnClick(byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                case "codStyllus":
                    util.SendKey(byInputCodStyllus, value, 10);
                    util.OnClick(byBotaoBuscar, 10);
                    Thread.Sleep(2000);
                    break;

                default:
                    break;
            }
        }


    }
}
