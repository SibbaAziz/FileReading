using FileReading.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading.Reading.Text
{
    public class TextEncryptedFileReader : IEncryptedFileReader
    {
        private IFileEncryption _encryption;
        private TextFileReader _reader;
        public TextEncryptedFileReader(IFileEncryption encryption)
        {
            _encryption = encryption;
        }
        public string Read(string path)
        {
            if (_reader == null)
                _reader = new TextFileReader();
            var text = _reader.Read(path);

            return _encryption?.Decrypt(text);
        }
    }
}
