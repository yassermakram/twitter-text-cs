using NUnit.Framework;
using TwitterText;

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
        public void Reply_At_TheStart_Should_Return_User()
        {
            Assert.AreEqual("user", _extractor.ExtractReplyScreenname("@user reply"), "Failed to extract reply at the start");
        }

        [Test]
        public void When_Extracting_Null_Should_Return_Null()
        {
            Assert.AreEqual(null, _extractor.ExtractReplyScreenname(null), "Failed to parse null tweet");
        }

        [Test]
        public void When_Extracting_Reply_With_Leading_Space_Should_Return_User()
        {
            Assert.AreEqual("user", _extractor.ExtractReplyScreenname(" @user reply"), "Failed to extract reply at the start");
        }
        #endregion

        #region Mention Tests
        [Test]
        public void When_Mention_At_The_Beginning_Should_Return_User()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames("@user mention"), "Failed to extract mention at the beginning");
        }

        [Test]
        public void When_Mention_At_The_Beginning_With_Whitespace_Should_Return_User()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames(" @user mention"), "Failed to extract mention at the beginning with white space");
        }

        [Test]
        public void When_Mention_At_The_Middle_Should_Return_User()
        {
            Assert.AreEqual(new string[] { "user" }, _extractor.ExtractMentionedScreennames("start @user mention"), "Failed to extract mention at the beginning with white space");
        }

        [Test]
        public void When_Mention_Multiple_Users_Should_Return_All()
        {
            Assert.AreEqual(new string[] { "user", "another" }, _extractor.ExtractMentionedScreennames("start @user mention and @another"), "Failed to extract mention at the beginning with white space");
        }
        #endregion
    }
}
