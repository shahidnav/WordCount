using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using WordCount.Main.Services;

namespace WordCount.UnitTests
{
    [TestFixture]
    public class PlainTextReportBuilderTests
    {
        [Test]
        public void Build_returns_message_if_WordMap_is_null()
        {
            const string expected = "Nothing to report as no words were provided.";
            var sut = new PlainTextReportBuilder();
            var actual = sut.Build(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_returns_message_if_WordMap_is_empty()
        {
            const string expected = "Nothing to report as no words were provided.";
            var sut = new PlainTextReportBuilder();
            var actual = sut.Build(new Collection<KeyValuePair<string, int>>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Build_returns_report_if_WordMap_is_populated()
        {
            var expected = string.Concat("WORD - 2", Environment.NewLine, "ANOTHERWORD - 3", Environment.NewLine);
            var sut = new PlainTextReportBuilder();
            var wordMap = new Collection<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("WORD", 2),
                new KeyValuePair<string, int>("ANOTHERWORD", 3)
            };
            
            var actual = sut.Build(wordMap);

            Assert.AreEqual(expected, actual);
        }
    }
}