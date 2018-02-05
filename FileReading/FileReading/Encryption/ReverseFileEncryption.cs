using System.Linq;

namespace FileReading.Encryption
{
    public class ReverseFileEncryption : IFileEncryption
    {
        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            return new string(text.Reverse().ToArray());
        }

        public string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            return new string(text.Reverse().ToArray());
        }
    }
}
