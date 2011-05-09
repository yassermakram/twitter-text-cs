using NUnit.Framework;
using TwitterText;
using System.Collections.Generic;

namespace twitter_text_cs_tests
{
    public class ExtractorTest
    {
        private Extractor _extractor;
        [SetUp]
        public void Init()
        {
            _extractor = new Extractor();
        }

        #region Reply Tests
        [Test]
        public void reply_at_start_should_return_user()
        {
            Assert.AreEqual("user", _extractor.ExtractReplyScreenname("@user reply"), "Failed to extract reply at the start");
        }

        [Test]
        public void extracting_null_should_return_null()
        {
            Assert.AreEqual(null, _extractor.ExtractReplyScreenname(null), "Failed to parse null tweet");
        }

        [Test]
        public void reply_with_leading_space_should_return_user()
        {
            Assert.AreEqual("user", _extractor.ExtractReplyScreenname(" @user reply"), "Failed to extract reply at the start");
        }
        #endregion

        #region Mention Tests
        [Test]
        public void mention_at_The_beginning_should_return_user()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames("@user mention"), "Failed to extract mention at the beginning");
        }

        [Test]
        public void mention_at_the_beginning_with_whitespace_should_return_user()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames(" @user mention"), "Failed to extract mention at the beginning with white space");
        }

        [Test]
        public void mention_at_the_middle_should_return_user()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames("start @user mention"), "Failed to extract mention at the middle");
        }

        [Test]
        public void mention_multiple_users_should_return_all()
        {
            Assert.AreEqual(new string[] { "user", "another" }, _extractor.ExtractMentionedScreennames("start @user mention and @another"), "Failed to extract mention for multiple users");
        }
        #endregion

        #region Hashtag Tests
        [Test]
        public void extract_hashtag_at_the_beginning_should_return_hashtag()
        {
            List<string> hashtags = _extractor.ExtractHashtags("#hashtag tweet");

            Assert.AreEqual(hashtags, new List<string>(){"hashtag"});
        }

        [Test]
        public void extract_hashtag_with_leading_space()
        {
            List<string> hashtags = _extractor.ExtractHashtags(" #hashtag tweet");

            Assert.AreEqual(hashtags, new List<string>() { "hashtag" });
        }

        [Test]
        public void extract_hashtag_mid_text()
        {
            List<string> hashtags = _extractor.ExtractHashtags("text #hashtag tweet");

            Assert.AreEqual(hashtags, new List<string>() { "hashtag" });
        }

        [Test]
        public void extract_multiple_hashtags()
        {
            List<string> hashtags = _extractor.ExtractHashtags("text #hashtag tweet #another");

            Assert.AreEqual(hashtags, new List<string>() { "hashtag", "another" });
        }
        #endregion
    }
}
