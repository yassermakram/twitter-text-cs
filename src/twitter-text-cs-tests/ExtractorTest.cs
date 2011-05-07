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
    }
}
