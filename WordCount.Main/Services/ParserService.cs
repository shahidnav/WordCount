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
                    // We dont want to return blank words, so lets ignore them
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    yield return word.Trim().ToUpperInvariant();

                    // reset for building up the next word
                    word = null;
                }
                else
                {
                    // word construction in progress
                    word += character;
                }
            }
        }

        private static bool IsCharacterAWordDelimeter(char character)
        {
            // Assuming words will only contain alphabetic characters.
            return (! char.IsLetter(character));
        }
    }
}