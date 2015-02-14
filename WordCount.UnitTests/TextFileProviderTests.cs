using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using NUnit.Framework;
using WordCount.Main.Providers;

namespace WordCount.UnitTests
{
    [TestFixture]
    public class TextFileProviderTests
    {
        [Test, ExpectedExceptionAttribute(typeof (ArgumentException))]
        public void Constructor_throws_ArgumentException_if_file_does_not_exist()
        {
            var sut = new TextFileProvider("", 1024);
        }

        [Test]
        public void Constructor_doesnt_throw_if_file_exists()
        {
            var sut = new TextFileProvider("SampleTextFile\\dummy.txt", 1024);
        }

        [Test]
        public void GetCharacters_returns_chars_from_sample_file()
        {
            const string path = "SampleTextFile\\dummyForTesting.txt";
            var expected = new Collection<char>
            {
                'T',
                'h',
                'i',
                's',
                ' ',
                'i',
                's',
                ' ',
                's',
                'o',
                'm',
                'e',
                ' ',
                't',
                'e',
                'x',
                't',
                ' ',
                'i',
                'n',
                ' ',
                't',
                'h',
                'e',
                ' ',
                'f',
                'i',
                'l',
                'e',
                '.'
            };

            if (!File.Exists(path))
            {
                // Create the file. 
                using (var fs = File.Create(path))
                {
                    var info = new UTF8Encoding(true).GetBytes("This is some text in the file.");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            var sut = new TextFileProvider(path, 1024);

            var actual = sut.GetCharacters();

            CollectionAssert.AreEqual(expected, actual);
        }
        
    }
}