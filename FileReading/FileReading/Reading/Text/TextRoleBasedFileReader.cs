using FileReading.Security;

namespace FileReading.Reading.Text
{
    public class TextRoleBasedFileReader : IRoleBasedFileReader
    {
        private ISecurity _security;
        private TextFileReader _reader;
        public TextRoleBasedFileReader(ISecurity security)
        {
            _security = security;
        }
        public string Read(string path)
        {
            if (!_security.CanRead(path))
                return string.Empty; // Or Throw Exception

            if (_reader == null)
                _reader = new TextFileReader();
            return _reader.Read(path);
        }
    }
}
