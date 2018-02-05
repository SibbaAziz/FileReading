namespace FileReading.Encryption
{
    public interface IFileEncryption
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
