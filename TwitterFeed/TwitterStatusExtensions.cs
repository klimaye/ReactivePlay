using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace TwitterFeed
{
    public static class TwitterStatusExtensions
    {
        public static bool HasHashTag(this TwitterStatus @this, string hashTag)
        {
            var hashTags = @this.Entities.HashTags;
            if (hashTags == null || hashTags.Count == 0)
                return false;
            var result = hashTags.Any(x => x.Text.ToLower().Contains(hashTag.ToLower()));
            return result;
        }
    }
}
