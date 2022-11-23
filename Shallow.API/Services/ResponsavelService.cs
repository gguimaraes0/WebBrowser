using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.Newtonsoft.Json;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using RestRequest = RestSharp.RestRequest;

namespace Shallow.API.Services
{
    public class ResponsavelService
    {
        public static string postResponsavel(ResponsavelModel responsavelModel)
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/responsavel");
            RestRequest request = new RestRequest();
            request.AddJsonBody(responsavelModel);
            
            IRestResponse response = null;
            response = client.Post(request);
            var cont = response.Content;
            return cont;
        }
        public static List<ResponsavelModel> getResponsavel()
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/responsavel");
            RestRequest request = new RestRequest();
            IRestResponse response = null;
            response = client.Get(request);
            var cont = response.Content;
            List<ResponsavelModel> listResponsavel = JsonConvert.DeserializeObject<List<ResponsavelModel>>(cont);
            return listResponsavel;
        }

        public static string deleteResponsavel(int responsavelID)
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/responsavel");
            RestRequest request = new RestRequest();
            IRestResponse response = null;

            var id = responsavelID.ToString();
            //ainda nn funciona
            string body = $@" ""id"" : ""{id}"" ";
            request.AddJsonBody(body);


            response = client.Delete(request);
            var cont = response.Content;
            return cont;
        }
    }
}
