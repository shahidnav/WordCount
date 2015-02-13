using System.Collections.Generic;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<string> ParseWords(IEnumerable<char> inputCharacters)
        {
            var word = string.Empty;

            foreach (var character in inputCharacters)
            {
                if (IsCharacterAWordDelimeter(character))
                {
                    if (word.Trim() == string.Empty) continue;

                    yield return word.Trim().ToUpperInvariant();
                    word = string.Empty;
                }

                word += character;
            }
        }

        private static bool IsCharacterAWordDelimeter(char character)
        {
            return (! char.IsLetter(character));
        }
    }
}