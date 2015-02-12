using System.Collections.Generic;
using System.IO;
using System.Linq;
using WordCount.Main.Interfaces;

namespace WordCount.Main
{
    public class Controller : IController
    {
        private readonly string _fullPathToTextFile;
        private Dictionary<string, long> _distinctWordsToCountMap;

        public Controller(string fullPathToTextFile)
        {
            _fullPathToTextFile = fullPathToTextFile;
            _distinctWordsToCountMap = new Dictionary<string, long>();
        }

        public void Execute()
        {
            
        }
        
        public string Report()
        {
            throw new System.NotImplementedException();
        }

        public static IEnumerable<string> ParseWords(string fullPathToTextFile)
        {
            using (var fileReader = new StreamReader(File.OpenRead(fullPathToTextFile)))
            {
                var buffer = new char[500];
                while (! fileReader.EndOfStream)
                {
                    
                    fileReader.ReadBlock(buffer, buffer.Count(), 500 - buffer.Length);
                    var words = buffer.ToString();
                    
                    foreach (var word in words.Split(' '))
                    {
                        yield return word;
                    }
                }
            }
        }
    }
}