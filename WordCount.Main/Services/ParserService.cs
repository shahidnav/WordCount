using System.Collections.Generic;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<string> ParseWords(IEnumerable<char> inputCharacters)
        {
            string word = null;

            foreach (var character in inputCharacters)
            {
                if (IsCharacterAWordDelimeter(character))
                {
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    yield return word.Trim().ToUpperInvariant();
                    word = string.Empty;
                }
                else
                {
                    word += character;
                }
            }
        }

        private static bool IsCharacterAWordDelimeter(char character)
        {
            return (! char.IsLetter(character));
        }
    }
}