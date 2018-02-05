using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReading.Reading.Text;
using FileReading.Encryption;
using FileReading.Security;
using System.Collections.Generic;

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

        [TestMethod]
        public void Admin_Read()
        {
            //Arrange
            ISecurity security = new RoleBasedSecurity(Role.Admin);
            var reader = new TextRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Text.txt");
            //Assert 
            Assert.AreEqual("Test text file reader", xml);
        }

        [TestMethod]
        public void Authorized_User_Read()
        {
            //Arrange
            List<string> accessibleFiles = new List<string>()
            {
                "Text.txt"
            };
            ISecurity security = new RoleBasedSecurity(Role.User, accessibleFiles);

            var reader = new TextRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Text.txt");
            //Assert 
            Assert.AreEqual("Test text file reader", xml);
        }

        [TestMethod]
        public void UnAuthorized_User_Read()
        {
            //Arrange

            ISecurity security = new RoleBasedSecurity(Role.User, null);

            var reader = new TextRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Text.txt");
            //Assert 
            Assert.AreEqual("", xml);
        }

        [TestMethod]
        public void UnAuthorized_Different_File_User_Read()
        {
            //Arrange
            List<string> accessibleFiles = new List<string>()
            {
                "DifferentFile.txt"
            };
            ISecurity security = new RoleBasedSecurity(Role.User, accessibleFiles);

            var reader = new TextRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Text.txt");
            //Assert 
            Assert.AreEqual("", xml);
        }
    }
}
