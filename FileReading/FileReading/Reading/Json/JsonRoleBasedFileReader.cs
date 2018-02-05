using FileReading.Security;

namespace FileReading.Reading.Json
{
    public class JsonRoleBasedFileReader : IRoleBasedFileReader
    {
        private ISecurity _security;
        private JsonFileReader _reader;
        public JsonRoleBasedFileReader(ISecurity security)
        {
            _security = security;
        }
        public string Read(string path)
        {
            if (!_security.CanRead(path))
                return string.Empty; // Or Throw Exception

            if (_reader == null)
                _reader = new JsonFileReader();
            return _reader.Read(path);
        }
    }
}
