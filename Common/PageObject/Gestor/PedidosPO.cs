using OpenQA.Selenium;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.PageObject
{
    public class PedidosPO
    {
        Utilitarios util;
        private IWebDriver driver;
        private By byBotaoFiltro;
        private By byInputNome;
        private By byInputCodStyllus;
        private By bySelectStatus;
        private By byInputValorMin;
        private By byInputValorMax;
        private By bySelectFormaPagamento;
        private By byInputDataInicio;
        private By byInputDataFim;
        private By bySelectStatusPagamento;
        private By byBotaoBuscar;
        private By byTdNome;
        private By byTdCod;
        private By byOptionNovo;
        private By byTdStatus;
        private By byTdValor;
        
        public PedidosPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            byBotaoFiltro = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/button");
            byInputNome = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[1]/div/div/div[1]/div/input");
            byInputCodStyllus = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[2]/div/div/div[1]/div/input");
            bySelectStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[3]/div/div/div[1]/div[1]/div[1]");
            byInputValorMin = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[4]/div/div/div[1]/div/input");
            byInputValorMax = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[5]/div/div/div[1]/div/input");
            bySelectFormaPagamento = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[6]/div/div/div[1]/div[1]/div[1]");
            byInputDataInicio = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[7]/div[1]/div[2]/div[1]/div/input");
            byInputDataFim = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[8]/div[1]/div[2]/div[1]/div/input");
            bySelectStatusPagamento = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[9]/div/div/div[1]/div[1]/div[1]");
            byBotaoBuscar = By.CssSelector("button.primary");
            byTdNome = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
            byTdCod = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]");
            byOptionNovo = By.XPath("/html/body/div/div[2]/div/div[2]/div/div");
            byTdStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]");
            byTdValor = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]");
        }



        public void AplicarFiltro(string value, string field)
        {
            switch (field)
            {
                case "nome":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputNome, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "codStyllus":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputCodStyllus, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "status":
                    util.OnClick(byBotaoFiltro, 30);
                    util.OnClick(bySelectStatus, 30);
                    util.OnClick(byOptionNovo, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "valorMin":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputValorMin, "502", 30);
                    util.SendKey(byInputValorMax, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "formaPag":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(bySelectFormaPagamento, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "dataInicio":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputDataInicio, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "dataFim":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputDataFim, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "statusPag":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(bySelectStatusPagamento, value, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                default:
                    break;
            }
        }

        public string EncontrarPedido(string field)
        {
            switch (field)
            {
                case "nome":
                    string nome = util.GetText(byTdNome, 30); 
                    return nome;

                case "codStyllus":
                    string cod = util.GetText(byTdCod, 30);
                    return cod;

                case "status":
                    string status = util.GetText(byTdStatus, 30);
                    return status;

                case "valorMin":
                    string valor = util.GetText(byTdValor, 30);
                    return valor;

                default:
                    return "não encontrou";
            }
        }
    }
}
