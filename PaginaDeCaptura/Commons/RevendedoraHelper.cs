using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace PaginaCaptura.Commons
{
    public static class RevendedoraHelper
    {
        
        public static string GetNome()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) {  RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["nome"];
            return result;
        }

        public static string GetTelefone()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = "00" + output["telefone_fixo"];
            return result;
        }

        public static string GetCEP()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["cep"];
            return result;
        }

        public static string GetNumero()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["numero"];
            return result;
        }

        public static string GetCPF()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=0&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["cpf"];
            return result;
        }

        public static string GetNascimento()
        {
            var client = new RestClient("https://www.4devs.com.br/ferramentas_online.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddHeader("authority", "www.4devs.com.br");
            request.AddHeader("accept", "/");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.150 Safari/537.36";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://www.4devs.com.br");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("referer", "https://www.4devs.com.br/gerador_de_pessoas");
            request.AddHeader("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            request.AddHeader("cookie", "_ga=GA1.3.580329436.1610302843; __gads=ID=4cc6fa1a418ed17f:T=1610302846:S=ALNI_MZLaudRMe_yqHi0WMoVl-_mi74cKA; _gid=GA1.3.2033429125.1613162051; _gat=1");
            request.AddParameter("application/x-www-form-urlencoded", "acao=gerar_pessoa&sexo=I&pontuacao=N&idade=45&cep_estado=&txt_qtde=1&cep_cidade=", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["data_nasc"];
            return result;
        }



    }
}
