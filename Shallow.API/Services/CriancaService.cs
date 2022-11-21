using Newtonsoft.Json;
using RestSharp;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shallow.API.Services
{
    public class CriancaService
    {
        public static List<CriancaModel> getCrianca()
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/crianca");
            RestRequest request = new RestRequest();
            IRestResponse response = null;
            response = client.Get(request);
            var cont = response.Content;
            List<CriancaModel> crianca = JsonConvert.DeserializeObject<List<CriancaModel>>(cont);
            return crianca;
        }
    }
}
