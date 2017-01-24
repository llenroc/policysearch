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

namespace PolicySearch.Controllers
{
    public class PolicyController : ApiController
    {
        [ResponseType(typeof(List<Models.Policy>))]
        [HttpPost]
        public IHttpActionResult PostPolicies(Models.SearchDetails searchDetails)
        {
            MakeRequest(searchDetails.SearchPhrase);
            return Ok();
        }        

        private async Task<Models.CognitiveResult> MakeRequest(string searchPhrase)
        {
            try
            {
                var config = (Configuration.LuisConfig)ConfigurationManager.GetSection("azureSettings/luis");

                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString("q=" +searchPhrase);

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", config.SubscriptionKey);

                var uri = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/{config.AppId}?" + queryString;

                var response = await client.GetAsync(uri);

                var json = await response.Content.ReadAsStringAsync();       
                
                var result = JsonConvert.DeserializeObject<Models.CognitiveResult>(json);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
