using System;
using System.Net;
using Newtonsoft.Json;

namespace Services
{
    public class ViaCEP
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        public static DataAccess.Endereco BuscarEnderecoVIACEP(string cep)
        {
            string NovoEndereco = String.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            string conteudo = wc.DownloadString(NovoEndereco);

            DataAccess.Endereco end = JsonConvert.DeserializeObject<DataAccess.Endereco>(conteudo);

            return end;
        }
    }
}
