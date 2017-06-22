using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Service
{
    public class Client
    {
        static HttpClient client = new HttpClient();

        public static async Task<List<Repository>> GetRepositores(string url)
        {
            List<Repository> list = null;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var array = JObject.Parse(responseString)["items"];
                list = JsonConvert.DeserializeObject<List<Repository>>(array.ToString());
            }
            return list;
        }

        public static async Task<List<PullRequest>> GetPullRequests(string url)
        {
            List<PullRequest> list = null;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<PullRequest>>(responseString);
            }
            return list;
        }
    }
}
