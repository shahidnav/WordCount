using System.Collections.Generic;

namespace WordCount.Main.Interfaces
{
    public interface IParserService
    {
        IEnumerable<string> ParseWords(IEnumerable<char> inputCharacters);
    }
}