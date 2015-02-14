using System.Collections.ObjectModel;
using NUnit.Framework;
using WordCount.Main.Services;

namespace WordCount.UnitTests
{
    [TestFixture]
    public class ParserServiceTests
    {
        private ParserService _sut;

        [TestFixtureSetUp]
        public void Setup()
        {
            _sut = new ParserService();
        }

        public void IsCharacterAWordDelimeter_returns_true__given_a_letter()
        {
            Assert.IsTrue(_sut.IsCharacterAWordDelimeter('A'));
        }

        public void IsCharacterAWordDelimeter_returns_False__given_a_number()
        {
            Assert.IsFalse(_sut.IsCharacterAWordDelimeter('9'));
        }

        public void IsCharacterAWordDelimeter_returns_False__given_a_whitespace()
        {
            Assert.IsFalse(_sut.IsCharacterAWordDelimeter(' '));
        }

        public void IsCharacterAWordDelimeter_returns_False__given_a_punctuation()
        {
            Assert.IsFalse(_sut.IsCharacterAWordDelimeter('.'));
        }

        [Test]
        public void ParseWords_returns_empty_given_empty_input()
        {
            var empty = new Collection<char>();
            var actual = _sut.ParseWords(empty);

            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void ParseWords_returns_empty_given_nonalpha_chars_only()
        {
            var nonAlphachars = new Collection<char> { '.', '/', '3', ' ', '$' };
            var actual = _sut.ParseWords(nonAlphachars);

            CollectionAssert.IsEmpty(actual);
        }

        [Test]
        public void ParseWords_returns_only_capitalised_alpha_chars_given_mixed_chars_ending_with_a_alpha()
        {
            var mixedChars = new Collection<char> {'.', '/', '3', ' ', '$', 'd', 'o', 'g', '.', 'B', 'a', 'r', 'k', 'S'};
            var expected = new Collection<string> {"DOG", "BARKS"};
            var actual = _sut.ParseWords(mixedChars);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}