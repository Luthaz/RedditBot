using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace RedditBot
{
    class Authenticate
    {

        private DateTime _timeLeft;
        private string _name;
        private string _version;
        private string _accessToken;

        public Authenticate(string name, string version)
        {
            _timeLeft = DateTime.Now;
            _name = name;
            _version = version;
        }

        public void AuthenticateToken(string clientId, string clientSecret, string redditUsername, string redditPassword)
        {
            using (var client = new HttpClient())
            {
                var authenticationArray = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
                var encodedAuthenticationString = Convert.ToBase64String(authenticationArray);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encodedAuthenticationString);

                client.DefaultRequestHeaders.Add("User-Agent", $"{_name} /v{_version} by {redditUsername}");

                var formData = new Dictionary<string, string>{

                     { "grant_type", "password" },

                     { "username", redditUsername },

                     { "password", redditPassword }

                     };

                var encodedFormData = new FormUrlEncodedContent(formData);
                var authUrl = "https://www.reddit.com/api/v1/access_token";
                var response = client.PostAsync(authUrl, encodedFormData).GetAwaiter().GetResult();

                // Response Code

                Console.WriteLine(response.StatusCode);

                // Actual Token

                var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var accessToken = JObject.Parse(responseData).SelectToken("access_token").ToString();
                _timeLeft = DateTime.Now.AddSeconds(Double.Parse(JObject.Parse(responseData).SelectToken("expires_in").ToString()));
                _accessToken = accessToken;
            }
        }

        public string sendAccesstoken()
        {
            return _accessToken;
        }

        public int timeLeftInSeconds()
        {
            return Convert.ToInt32((_timeLeft - DateTime.Now).TotalSeconds);
        }

        public bool isAuthenticated()
        {
            int timeLeft = timeLeftInSeconds();
            if (timeLeft > 0){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
