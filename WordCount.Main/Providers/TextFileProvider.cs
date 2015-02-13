using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Providers
{
    public class TextFileProvider : ITextFileProvider
    {
        private const string FileNotFoundExceptionMessageFormat = "text file was not found at the specified path: {0}";
        private readonly string _fullPathForTextfile;
        private readonly Encoding _encoding;

        public TextFileProvider(string fullPathForTextfile, Encoding encoding)
        {
            _fullPathForTextfile = fullPathForTextfile;
            _encoding = encoding;
            if (!File.Exists(_fullPathForTextfile))
            {
                throw new ArgumentException(string.Format(FileNotFoundExceptionMessageFormat,
                    _fullPathForTextfile));
            }
        }

        public IEnumerable<char> GetCharacters()
        {
            using (var streamreader = File.OpenText(_fullPathForTextfile))
            {
                while (! streamreader.EndOfStream)
                {
                    yield return _encoding.GetChars(BitConverter.GetBytes(streamreader.Read())).First();
                }
            }
        }
    }
}