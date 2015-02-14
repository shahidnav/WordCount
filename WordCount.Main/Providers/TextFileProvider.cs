using System;
using System.Collections.Generic;
using System.IO;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Providers
{
    public class TextFileProvider : ITextFileProvider
    {
        private const string FileNotFoundExceptionMessageFormat = "text file was not found at the specified path: {0}";

        private readonly int _bufferSize;
        private readonly string _fullPathForTextfile;

        public TextFileProvider(string fullPathForTextfile, int bufferSize)
        {
            _fullPathForTextfile = fullPathForTextfile;
            _bufferSize = bufferSize;
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
                var buffer = new char[_bufferSize];
                while (! streamreader.EndOfStream)
                {
                    streamreader.ReadBlock(buffer, 0, _bufferSize);
                    foreach (var character in buffer)
                    {
                        if (character.Equals('\0'))
                        {
                            break;
                        }

                        yield return character;
                    }
                }
            }
        }
    }
}