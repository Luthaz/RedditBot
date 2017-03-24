using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RedditBot
{
    class RedditBot
    {
        private string _redditUsername;
        private string _name;
        private string _clientVersion;
        private string _subredditID;
        private string _articleID;
        private string _accessToken;

        public RedditBot(string name, string version, string redditUsername, string subredditID, string articleID, string accessToken)
        {
            _name = name;
            _clientVersion = version;
            _redditUsername = redditUsername;
            _subredditID = subredditID;
            _articleID = articleID;
            _accessToken = accessToken;
        }


        public void GetNasirAndComment()
        {

            using (var client = new HttpClient()) {
                string url = "https://oauth.reddit.com/r/" + _subredditID + "/comments/" + _articleID;


                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", _accessToken);
                client.DefaultRequestHeaders.Add("User-Agent", $"{_name} /v{_clientVersion} by {_redditUsername}");

                var response = client.GetStringAsync(url).GetAwaiter().GetResult();

                var json = JArray.Parse(response);//[1].SelectToken("data").SelectToken("children")[0].SelectToken("data").SelectToken("body");
                var comment = json[1]["data"]["children"][0]["data"]["body"].Value<string>();
                Console.WriteLine(comment);
            }
        }
    }
}
