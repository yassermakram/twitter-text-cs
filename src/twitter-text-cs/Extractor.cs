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


    }
}
