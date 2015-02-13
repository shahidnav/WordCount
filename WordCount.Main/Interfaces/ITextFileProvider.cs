using System.Collections.Generic;

namespace WordCount.Main.Interfaces
{
    public interface ITextFileProvider
    {
        IEnumerable<char> GetCharacters();
    }
}