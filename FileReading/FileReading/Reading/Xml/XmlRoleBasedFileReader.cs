using FileReading.Security;

namespace FileReading.Reading.Xml
{
    public class XmlRoleBasedFileReader : IRoleBasedFileReader
    {
        private ISecurity _security;
        private XmlFileReader _reader;
        public XmlRoleBasedFileReader(ISecurity security)
        {
            _security = security;
        }
        public string Read(string path)
        {
            if (!_security.CanRead(path))
                return string.Empty; // Or Throw Exception

            if (_reader == null)
                _reader = new XmlFileReader();
            return _reader.Read(path);
        }
    }
}
