using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReading.Reading.Text;
using FileReading.Encryption;

namespace FileReading.Test
{
    [TestClass]
    public class TextFile
    {
        [TestMethod]
        public void Read()
        {
            //Arrange
            var reader = new TextFileReader();

            //Act 
            var text = reader.Read("Text.txt");
            //Assert 
            Assert.AreEqual("Test text file reader", text);
        }

        [TestMethod]
        public void EncryptedRead()
        {
            //Arrange
            IFileEncryption encryption = new ReverseFileEncryption();
            var reader = new TextEncryptedFileReader(encryption);

            //Act 
            var text = reader.Read("EncryptedText.txt");
            //Assert 
            Assert.AreEqual("Test text file reading", text);
        }

    }
}
