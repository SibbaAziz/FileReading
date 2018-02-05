using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReading.Reading.Json;
using FileReading.Encryption;
using System.Collections.Generic;
using FileReading.Security;

namespace FileReading.Test
{
    [TestClass]
    public class JsonFile
    {
        [TestMethod]
        public void Read()
        {
            //Arrange
            var reader = new JsonFileReader();

            //Act 
            var json = reader.Read("File.json");
            //Assert 
            Assert.AreEqual("{\r\n\"Id\" : 5,\r\n\"Name\" : \"Paul\"\r\n}", json);
        }

        [TestMethod]
        public void EncryptedRead()
        {
            //Arrange
            IFileEncryption encryption = new ReverseFileEncryption();
            var reader = new JsonEncryptedFileReader(encryption);

            //Act 
            var json = reader.Read("EncryptedFile.json");
            //Assert 
            Assert.AreEqual("{\"Id\" : 5,\"Name\" : \"Paul\"}", json);
        }

        [TestMethod]
        public void Admin_Read()
        {
            //Arrange
            ISecurity security = new RoleBasedSecurity(Role.Admin);
            var reader = new JsonRoleBasedFileReader(security);

            //Act 
            var json = reader.Read("File.json");
            //Assert 
            Assert.AreEqual("{\r\n\"Id\" : 5,\r\n\"Name\" : \"Paul\"\r\n}", json);
        }

        [TestMethod]
        public void Authorized_User_Read()
        {
            //Arrange
            List<string> accessibleFiles = new List<string>()
            {
                "File.json"
            };
            ISecurity security = new RoleBasedSecurity(Role.User, accessibleFiles);

            var reader = new JsonRoleBasedFileReader(security);

            //Act 
            var json = reader.Read("File.json");
            //Assert 
            Assert.AreEqual("{\r\n\"Id\" : 5,\r\n\"Name\" : \"Paul\"\r\n}", json);
        }

        [TestMethod]
        public void UnAuthorized_User_Read()
        {
            //Arrange

            ISecurity security = new RoleBasedSecurity(Role.User, null);

            var reader = new JsonRoleBasedFileReader(security);

            //Act 
            var json = reader.Read("File.json");
            //Assert 
            Assert.AreEqual("", json);
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

            var reader = new JsonRoleBasedFileReader(security);

            //Act 
            var json = reader.Read("File.json");
            //Assert 
            Assert.AreEqual("", json);
        }
    }
}
