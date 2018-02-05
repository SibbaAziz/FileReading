using FileReading.Encryption;

namespace FileReading.Reading.Xml
{
    public class XmlEncryptedFileReader : IEncryptedFileReader
    {
        private IFileEncryption _encryption;
        private XmlFileReader _reader;

        public XmlEncryptedFileReader(IFileEncryption encryption)
        {
            _encryption = encryption;
        }

        public string Read(string path)
        {
            if (_reader == null)
                _reader = new XmlFileReader();
            var text = _reader.Read(path);

            return _encryption?.Decrypt(text);
        }
    }
}
