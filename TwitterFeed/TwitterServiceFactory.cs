using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterFeed
{
    class TwitterServiceFactory
    {
        //get your credentials from dev.twitter.com
        private const string API_KEY = "";
        private const string API_SECRET = "";
        private const string ACCESS_TOKEN = "";
        private const string ACCESS_TOKEN_SECRET = "";

        public static TwitterService create()
        {
            var service = new TwitterService(API_KEY, API_SECRET);
            service.AuthenticateWith(ACCESS_TOKEN, ACCESS_TOKEN_SECRET);
            return service;
        }
    }
}
