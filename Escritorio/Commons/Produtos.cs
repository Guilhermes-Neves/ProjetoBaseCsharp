using System;
using System.Collections.Generic;

namespace Escritorio.Commons
{
    public class Produtos
    {
        public string Referencia = "";
        public string Grupo = "";
        public string Tamanho = "";
        public string Cor = "";
        public string Quantidade = "";
        public string DescontoFixo = "";
        public string Desconto = "";

        public List<Produtos> RetornarProdutos()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("PLN-1319/20-000", "20", "PLN", "SEM PEDRA", "1"));
            listaProdutos.Add(CriarProduto("ANP-1242/UN-000", "UNICO", "ANP", "SEM PEDRA", "1"));
            listaProdutos.Add(CriarProduto("PQN-1720/UN-001", "UNICO", "PQN", "CRYSTAL - 001", "1"));
            listaProdutos.Add(CriarProduto("LI3-0011/P-007", "P", "LI3", "PRETO", "1"));
            listaProdutos.Add(CriarProduto("EM3-0008/UN-007", "UNICO", "EM3", "PRETO", "1"));
            listaProdutos.Add(CriarProduto("CJI-0078/UN-059", "UNICO", "CJI", "RESINA MULTICORES", "1"));
            listaProdutos.Add(CriarProduto("PGP-1078/UN-000", "UNICO", "PGP", "SEM PEDRA", "1"));
            listaProdutos.Add(CriarProduto("PGN-0750/UN-000", "UNICO", "PGN", "SEM PEDRA", "1"));
            listaProdutos.Add(CriarProduto("CJI-0076/UN-059", "UNICO", "CJI", "RESINA MULTICORES", "1"));

            return RetornarListaAleatoria(listaProdutos);
        }

        public List<Produtos> RetornarProdutosSemEstoque()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("LI3-0007/P-007", "", "", "", ""));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosValorAte100()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("CJI-0076/UN-059", "UNICO", "CJI", "RESINA MULTICORES", "1"));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosUltrapassandoLimiteCredito()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("AG3-0015", "UNICO", "CJI", "SEM PEDRA", "11"));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosValorAte199()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("PLN-1319/20-000", "20", "PLN", "SEM PEDRA", "1"));
            listaProdutos.Add(CriarProduto("EM3-0008/UN-007", "UNICO", "EM3", "PRETO", "2"));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosValorAte400()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("LI3-0011/P-007", "P", "LI3", "PRETO", "10"));
            listaProdutos.Add(CriarProduto("EM3-0008/UN-007", "UNICO", "EM3", "PRETO", "4"));
            listaProdutos.Add(CriarProduto("PLN-1319/20-000", "20", "PLN", "SEM PEDRA", "1"));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosValorAte800()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("LI3-0011/P-007", "P", "LI3", "PRETO", "9"));
            listaProdutos.Add(CriarProduto("EM3-0008/UN-007", "UNICO", "EM3", "PRETO", "3"));
            listaProdutos.Add(CriarProduto("PLN-1319/20-000", "20", "PLN", "SEM PEDRA", "4"));

            return listaProdutos;
        }

        public List<Produtos> RetornarProdutosValorMaior800()
        {
            List<Produtos> listaProdutos = new List<Produtos>();

            listaProdutos.Add(CriarProduto("LI3-0011/P-007", "P", "LI3", "PRETO", "12"));
            listaProdutos.Add(CriarProduto("EM3-0008/UN-007", "UNICO", "EM3", "PRETO", "8"));
            listaProdutos.Add(CriarProduto("PLN-1319/20-000", "20", "PLN", "SEM PEDRA", "3"));

            return listaProdutos;
        }

        public List<Produtos> RetornarListaAleatoria(List<Produtos> listaProdutos)
        {
            List<Produtos> listaAleatoria = new List<Produtos>();

            int randomNumber = new Random().Next(1, listaProdutos.Count);

            for (int i = 0; i <= randomNumber; i++)
            {
                int produtoAleatorio = new Random().Next(listaProdutos.Count);
               
                if (!listaAleatoria.Contains(listaProdutos[produtoAleatorio]))
                {
                    listaProdutos[produtoAleatorio].Quantidade = new Random().Next(1, 10).ToString();
                    listaAleatoria.Add(listaProdutos[produtoAleatorio]);
                }
            }

            return listaAleatoria;
        }

        private Produtos CriarProduto(string referencia, string tamanho, string grupo, string indexCor, string quantidade)
        {
            Produtos produto = new Produtos();
            produto.Referencia = referencia;
            produto.Tamanho = tamanho;
            produto.Grupo = grupo;
            produto.Cor = indexCor;
            produto.Quantidade = quantidade;
            produto.DescontoFixo = ValidarDescontoFixo(produto.Grupo);
            return produto;
        }

        public string ValidarDesconto(Produtos produto, decimal valorSemDesconto)
        {
            bool possuiDescontoFixo = ValidarDescontoFixo(produto.Grupo) != null;
            if (possuiDescontoFixo)
            {
                string desconto = ValidarDescontoFixo(produto.Grupo);
                return desconto;
            } 
            else
            {
                string desconto = $"{ValidarFaixaDesconto(valorSemDesconto)}%";
                return desconto;
            }
        }

        private string ValidarDescontoFixo(string grupo)
        {
            return GruposComDescontoFixo30().Contains(grupo) ? "30%" : null;

        }

        private decimal ValidarFaixaDesconto(decimal valorSemDesconto)
        {
            switch (valorSemDesconto)
            {
                case decimal v when v < 100:
                    return 0;

                case decimal v when v < 199:
                    return 30;

                case decimal v when v < 400:
                    return 35;

                case decimal v when v < 800:
                    return 40;

                case decimal v when v >= 800:
                    return 50;

                default:
                    return 0;
            }

        }

        public List<string> GruposComDescontoFixo30()
        {
            return new List<string>
            {
                "FT2",
                "LI2",
                "FT3",
                "LI3",
                "EM2",
                "EM3",
                "ENC",
                "MAQ",
                "FIT",
                "LIN",
                "ACE",
                "ACES"
            };
        }

        public override string ToString()
        {
            return $"{Referencia}, {Tamanho}, {Cor} ,{Quantidade}";
        }
    }
}
