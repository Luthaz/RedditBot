using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace RedditBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientId = ConfigurationManager.AppSettings["clientId"];
            string clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            string redditUsername = ConfigurationManager.AppSettings["redditUsername"];
            string redditPassword = ConfigurationManager.AppSettings["redditPassword"];
            string name = "Dextersbotting AB";
            string version = "1.0";
            string subredditID = "sandboxtest";
            string articleID = "63l6kv";
            Authenticate access = new Authenticate(name, version);
            access.AuthenticateToken(clientId, clientSecret, redditUsername, redditPassword);
            string accessToken = access.sendAccesstoken();
            Console.WriteLine(accessToken);
            RedditBot comments = new RedditBot(name, version, redditUsername, subredditID, articleID, accessToken);
            comments.GetNasirAndComment();
            
            //TokenBucket bucket = new TokenBucket(60, 60);
            //Console.WriteLine(access.timeLeftInSeconds());
            //Console.WriteLine(access.isAuthenticated());
            Console.ReadKey();
        }
    }
}
