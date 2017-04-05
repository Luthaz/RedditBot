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
        private string _comment;

        public RedditBot(string name, string version, string redditUsername, string subredditID, string articleID, string accessToken)
        {
            _name = name;
            _clientVersion = version;
            _redditUsername = redditUsername;
            _subredditID = subredditID;
            _articleID = articleID;
            _accessToken = accessToken;
        }

        public string GetResponse()
        {
            using (var client = new HttpClient())
            {
                string url = "https://oauth.reddit.com/r/" + _subredditID + "/comments/" + _articleID;

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", _accessToken);
                client.DefaultRequestHeaders.Add("User-Agent", $"{_name} /v{_clientVersion} by {_redditUsername}");
                var response = client.GetStringAsync(url).GetAwaiter().GetResult();
                return response;
            }

        }

        public string ReplyToComment()
        {
            using (var client = new HttpClient())
            {
                string url = "https://oauth.reddit.com/api/comment" 

            }
        }

        public void CheckForRepliesAndComment(JToken commentResponse)
        {
            var children = commentResponse["data"]["children"];
            foreach (var c in children) {
                var text = c["data"]["body"];
                //Console.WriteLine(text);
                if (text.ToString().Contains("Nasir"))
                {
                    
                }
                if (c["data"]["replies"].ToString() != "")
                {
                    //Console.WriteLine(c["data"]["replies"]["body_html"]);
                    CheckForRepliesAndComment(c["data"]["replies"]);
                }
            }
        }

        public void GetNasirAndComment()
        {
            string response = GetResponse();
            var json = JArray.Parse(response);
            var comment = json[1];
            CheckForRepliesAndComment(comment);   
        }
    }
}
