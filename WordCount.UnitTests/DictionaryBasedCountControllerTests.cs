using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using WordCount.Main;
using WordCount.Main.Interfaces;

namespace WordCount.UnitTests
{
    [TestFixture]
    public class DictionaryBasedCountControllerTests
    {
        private DictionaryBasedCountController _sut;
        private Mock<ITextFileProvider> _mockedTextFileProvider;
        private Mock<IParserService> _mockedParserService;
        private Mock<IReportBuilder> _mockedReportBuilder;

        [TestFixtureSetUpAttribute]
        public void SetupSubjectUnderTest()
        {
            _mockedTextFileProvider = new Mock<ITextFileProvider>();
            _mockedParserService = new Mock<IParserService>();
            _mockedReportBuilder = new Mock<IReportBuilder>();

            _sut = new DictionaryBasedCountController(
                _mockedTextFileProvider.Object,
                _mockedParserService.Object,
                _mockedReportBuilder.Object);
        }

        [Test]
        public void Execute_Calls_TextFileProvider_GetCharacters()
        {
            _sut.Execute();

            _mockedTextFileProvider.Verify(service => service.GetCharacters(), Times.AtLeastOnce);
        }

        [Test]
        public void Execute_Calls_ParserService_ParseWords()
        {
            _sut.Execute();

            _mockedParserService.Verify(service => service.ParseWords(It.IsAny<IEnumerable<char>>()), Times.Once());
        }

        [Test]
        public void Report_Calls_ReportBuilder_Build()
        {
            _sut.Report();

            _mockedReportBuilder.Verify(service => service.Build(It.IsAny<IDictionary<string, int>>()), Times.Once());
        }

        [Test]
        public void Execute_populates_WordMap_with_distinct_words_and_correct_count()
        {
            var expectedWordMap = new Dictionary<string, int> {{"RIGHT", 2}, {"SAID", 1}, {"FRED", 1}};
            _mockedParserService.Setup(service => service.ParseWords(It.IsAny<IEnumerable<char>>()))
                .Returns(new Collection<string> {"RIGHT", "SAID", "FRED", "RIGHT"});

            _sut.Execute();

            CollectionAssert.AreEquivalent(expectedWordMap, _sut.DistinctWordtoCountMap);
        }
    }
}
