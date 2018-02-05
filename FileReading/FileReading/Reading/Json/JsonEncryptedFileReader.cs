using FileReading.Encryption;

namespace FileReading.Reading.Json
{
    public class JsonEncryptedFileReader : IEncryptedFileReader
    {
        private IFileEncryption _encryption;
        private JsonFileReader _reader;
        public JsonEncryptedFileReader(IFileEncryption encryption)
        {
            _encryption = encryption;
        }
        public string Read(string path)
        {
            if (_reader == null)
                _reader = new JsonFileReader();
            var text = _reader.Read(path);

            return _encryption?.Decrypt(text);
        }
    }
}
