using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TwitterText
{
    public class Extractor
    {
        public string ExtractReplyScreenname(string tweet)
        {
            if (string.IsNullOrEmpty(tweet))
                return null;

            var replyExpression = new Regex("^(?:[ ])*@([a-z0-9_]{1,20}).*", RegexOptions.IgnoreCase);

            var match = replyExpression.Match(tweet);
            if (match.Success)
                return match.Result("$1");
            else
                return null;
        }



        public string[] ExtractMentionedScreennames(string tweet)
        {
            if (string.IsNullOrEmpty(tweet))
                return null;
            var mentionExpression = new Regex("(^|[^a-z0-9_])@([a-z0-9_]{1,20})(?=(.|$))", RegexOptions.IgnoreCase);
            var matches = mentionExpression.Match(tweet);
            var result = new List<string>();
            while (matches.Success)
            {
                result.Add(matches.Result("$2"));
                matches = matches.NextMatch();
            }
            return result.ToArray();
        }

        public List<string> ExtractHashtags(string tweet)
        {
            if (string.IsNullOrEmpty(tweet))
                return null;
            var hashtags = new List<string>();
            var hashtagExpression = new Regex("(^|[^0-9A-Z&/]+)(#|\uFF03)([0-9A-Z_]*[A-Z_]+#*)", RegexOptions.IgnoreCase);
            var matches = hashtagExpression.Match(tweet);
            
            while (matches.Success)
            {
                hashtags.Add(matches.Result("$3"));
                matches = matches.NextMatch();
            }
            return hashtags;
        }
    }
}
