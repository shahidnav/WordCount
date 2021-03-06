﻿using System.Collections.Generic;
using WordCount.Main.Interfaces;

namespace WordCount.Main
{
    public class DictionaryBasedCountController : IDistinctCountController
    {
        private readonly IDictionary<string, int> _distinctWordtoCountMap;
        private readonly IParserService _parserService;
        private readonly IReportBuilder _reportBuilder;
        private readonly ITextFileProvider _textFileProvider;

        public DictionaryBasedCountController(ITextFileProvider textFileProvider, IParserService parserService, IReportBuilder reportBuilder)
        {
            _textFileProvider = textFileProvider;
            _parserService = parserService;
            _reportBuilder = reportBuilder;
            _distinctWordtoCountMap = new Dictionary<string, int>();
        }

        public IDictionary<string, int> DistinctWordtoCountMap
        {
            get { return _distinctWordtoCountMap; }
        }

        public void Execute()
        {
            foreach (var word in _parserService.ParseWords(_textFileProvider.GetCharacters()))
            {
                int currentWordcount;
                _distinctWordtoCountMap.TryGetValue(word, out currentWordcount);

                _distinctWordtoCountMap[word] = ++currentWordcount;
            }
        }

        public string Report()
        {
            return _reportBuilder.Build(_distinctWordtoCountMap);
        }
    }
}