using Newtonsoft.Json;
using RestSharp;
using Shallow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shallow.API.Services
{
    public static class SitesService
    {
        public static List<SiteModel> getSites()
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/site");
            RestRequest request = new RestRequest();
            IRestResponse response = null;
            response = client.Get(request);
            var cont = response.Content;
            List<SiteModel> sites = JsonConvert.DeserializeObject<List<SiteModel>>(cont);
            return sites;
        }

        public static List<SiteModel> getSitesByCriancaID(int criancaID)
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/site");
            RestRequest request = new RestRequest();
            IRestResponse response = null;
            response = client.Get(request);
            var cont = response.Content;
            List<SiteModel> sites = JsonConvert.DeserializeObject<List<SiteModel>>(cont);

            sites = sites.Where(s => s.criancaID == criancaID).ToList();
            return sites;
        }

        public static string postSite(SiteModel siteModel)
        {
            RestClient client = new RestClient("https://c33fbkz77k.execute-api.sa-east-1.amazonaws.com/v1/responsavel");
            RestRequest request = new RestRequest();
            request.AddJsonBody(siteModel);

            IRestResponse response = null;
            response = client.Post(request);
            var cont = response.Content;
            return cont;
        }
    }
}
