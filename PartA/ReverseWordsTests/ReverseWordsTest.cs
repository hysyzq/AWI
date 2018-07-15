using Reverse;
using Xunit;

namespace ReverseWordsTests
{

    /// <summary>
    /// Some examples of unitest.
    /// </summary>
    public class ReverseWordsTest
    {
        [Fact]
        public void SingleChar()
        {
            string result = ReverseWords.Reverse("A");
            Assert.Equal("A", result);
        }

        [Fact]
        public void Empty()
        {
            string result = ReverseWords.Reverse("");
            Assert.Equal("", result);
        }

        [Fact]
        public void whitespace()
        {
            string result = ReverseWords.Reverse(" ");
            Assert.Equal(" ", result);
        }

        [Fact]
        public void whitespaces()
        {
            string result = ReverseWords.Reverse("  ");
            Assert.Equal("  ", result);
        }

        [Fact]
        public void whitespaceHeadAndTail()
        {
            string result = ReverseWords.Reverse(" AB  ");
            Assert.Equal(" BA  ", result);
        }

        [Fact]
        public void mutliWords()
        {
            string result = ReverseWords.Reverse(" ABC DEF ,.: ");
            Assert.Equal(" CBA FED :., ", result);
        }
    }
}
