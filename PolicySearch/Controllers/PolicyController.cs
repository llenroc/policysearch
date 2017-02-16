using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace PolicySearch.Controllers
{
    public class PolicyController : ApiController
    {
        [ResponseType(typeof(List<Models.Policy>))]
        [HttpPost]
        public async Task<IHttpActionResult> PostPolicies(Models.SearchDetails searchDetails)
        {
            var request = await MakeRequest(searchDetails.SearchPhrase);

            var result = SearchPolicies(request);

            return result;
        }

        private async Task<Models.CognitiveResult> MakeRequest(string searchPhrase)
        {
            var config = (Configuration.LuisConfig)ConfigurationManager.GetSection("azureSettings/luis");

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString("q=" + searchPhrase);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config.SubscriptionKey);

            var uri = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/{config.AppId}?" + queryString;

            var response = await client.GetAsync(uri);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Models.CognitiveResult>(json);

            return result;
        }

        private IHttpActionResult SearchPolicies(Models.CognitiveResult cognitiveResults)
        {
            var intent = cognitiveResults.TopScoringIntent;

            var involvesGovernment = cognitiveResults.Entities.Any(entity => entity.Entity == "government official");

            if (intent.Intent == "GiveReference")
            {
                var appSettings = ConfigurationManager.AppSettings;

                var azureSearchKey = appSettings["AzureSearchKey"];
                var azureSearchName = appSettings["AzureSearchName"];
                var azureSearchIndex = appSettings["AzureSearchIndex"];

                var service = new SearchServiceClient(azureSearchName, new SearchCredentials(azureSearchKey));
                var indexClient = service.Indexes.GetClient(azureSearchIndex);

                //var response = indexClient.Documents.Search<Models.Policy>(searchPhrase);

                //return response.Results.Select(result => result.Document).ToList();
           
            }

            return Ok();
        }
    }
}
