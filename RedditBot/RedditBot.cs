using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace RedditBot
{
    class RedditBot
    {
        public void GetNasirAndComment()
        {
            private string _redditUsername;
            private string _name;
            private string _clientVersion;

            using (var client = new HttpClient()) {
                string SubredditID = "";
                string ArticleID = "";
                string url = "https://oauth.reddit.com/r/" + SubredditID + "/comments/" + ArticleID;


                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
                client.DefaultRequestHeaders.Add("User-Agent", $"{} /v{clientVersion} by {redditUsername}");

            }
        }
    }
}
