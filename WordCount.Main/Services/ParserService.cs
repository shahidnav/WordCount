using System.Collections.Generic;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<string> ParseWords(IEnumerable<char> inputCharacters)
        {
            var wordBuilder = new StringBuilder();

            foreach (var character in inputCharacters)
            {
                if (IsCharacterAWordDelimeter(character) )
                {
                    var word = wordBuilder.ToString();

                    // We dont want to return blank words, so lets ignore them
                    if (string.IsNullOrWhiteSpace(word)) continue;

                    yield return word.ToUpperInvariant();

                    // reset for building up the next word
                    wordBuilder.Clear();
                }
                else
                {
                    // word construction in progress
                    wordBuilder.Append(character);
                }
            }

            // the last character may not have been a delimeter, this can cause the last word to be missed
            if (wordBuilder.Length > 0)
            {
                yield return wordBuilder.ToString().ToUpperInvariant(); 
            }
        }

        public bool IsCharacterAWordDelimeter(char character)
        {
            // Assuming words will only contain alphabetic characters.
            return (! char.IsLetter(character));
        }
    }
}