using System;
using System.Linq;

namespace FileReading.Encryption
{
    public class XmlReverseFileEncryption : IFileEncryption
    {
        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var elements = text.Split('<', '>', '/').Distinct();

            foreach (var item in elements)
            {
                if(!string.IsNullOrEmpty(item))
                    text = text.Replace(item, new String(item.Reverse().ToArray()));
            }

            return text;
        }

        public string Encrypt(string text)
        {
            throw new NotImplementedException();
        }
    }
}
