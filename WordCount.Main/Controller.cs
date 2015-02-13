using System.Collections.Generic;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main
{
    public class Controller : IController
    {
        private readonly ITextFileProvider _textFileProvider;
        private readonly IParserService _parserService;
        private readonly Dictionary<string, int> _dictinctWordtoCountMap;

        public Controller(ITextFileProvider textFileProvider, IParserService parserService)
        {
            _textFileProvider = textFileProvider;
            _parserService = parserService;
            _dictinctWordtoCountMap = new Dictionary<string, int>();
        }

        public void Execute()
        {
            foreach (var word in _parserService.ParseWords(_textFileProvider.GetCharacters()))
            {
                int currentWordcount;
                _dictinctWordtoCountMap.TryGetValue(word, out currentWordcount);

                _dictinctWordtoCountMap[word] = ++currentWordcount;
            }
        }
        
        public string Report()
        {
            var reportBuilder = new StringBuilder();
            const string reportLineformat = "{0} - {1}";
            foreach (var wordAndCount in _dictinctWordtoCountMap)
            {
                reportBuilder.AppendFormat(reportLineformat, wordAndCount.Key, wordAndCount.Value);
                reportBuilder.AppendLine();
            }

            return reportBuilder.ToString();
        }
    }
}