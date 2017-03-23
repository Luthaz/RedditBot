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
            Authenticate access = new Authenticate("Dextersbotting AB", "1.0");
            access.AuthenticateToken(clientId, clientSecret, redditUsername, redditPassword);
            TokenBucket bucket = new TokenBucket(60, 60);
            Console.WriteLine(access.timeLeftInSeconds());
            Console.WriteLine(access.isAuthenticated());
            Console.ReadKey();
        }
    }
}
