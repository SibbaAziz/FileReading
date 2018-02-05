using FileReading.Encryption;
using FileReading.Reading.Xml;
using FileReading.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FileReading.Test
{

    [TestClass]
    public class XmlFile
    {
        [TestMethod]
        public void Read()
        {
            //Arrange
            var reader = new XmlFileReader();

            //Act 
            var xml = reader.Read("Test.xml");
            //Assert 
            Assert.AreEqual(
                            "<Person>" +
                            "<Id>1</Id>" +
                            "<Name>Paul</Name>" +
                            "</Person>", xml);
        }

        [TestMethod]
        public void Admin_Read()
        {
            //Arrange
            ISecurity security = new RoleBasedSecurity(Role.Admin);
            var reader = new XmlRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Test.xml");
            //Assert 
            Assert.AreEqual(
                            "<Person>" +
                            "<Id>1</Id>" +
                            "<Name>Paul</Name>" +
                            "</Person>", xml);
        }

        [TestMethod]
        public void Authorized_User_Read()
        {
            //Arrange
            List<string> accessibleFiles = new List<string>()
            {
                "Test.xml"
            };
            ISecurity security = new RoleBasedSecurity(Role.User, accessibleFiles);           

            var reader = new XmlRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Test.xml");
            //Assert 
            Assert.AreEqual(
                            "<Person>" +
                            "<Id>1</Id>" +
                            "<Name>Paul</Name>" +
                            "</Person>", xml);
        }

        [TestMethod]
        public void UnAuthorized_User_Read()
        {
            //Arrange
            
            ISecurity security = new RoleBasedSecurity(Role.User, null);

            var reader = new XmlRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Test.xml");
            //Assert 
            Assert.AreEqual("", xml);
        }

        [TestMethod]
        public void UnAuthorized_Different_File_User_Read()
        {
            //Arrange
            List<string> accessibleFiles = new List<string>()
            {
                "DifferentFile.xml"
            };
            ISecurity security = new RoleBasedSecurity(Role.User, accessibleFiles);

            var reader = new XmlRoleBasedFileReader(security);

            //Act 
            var xml = reader.Read("Test.xml");
            //Assert 
            Assert.AreEqual("", xml);
        }

        [TestMethod]
        public void EncryptedRead()
        {
            //Arrange
            IFileEncryption encryption = new XmlReverseFileEncryption(); 
            var reader = new XmlEncryptedFileReader(encryption);

            //Act 
            var xml = reader.Read("EncryptedXml.xml");

            //Assert 
            Assert.AreEqual(
                            "<Person>" +
                            "<Id>1</Id>" +
                            "<Name>Paul</Name>" +
                            "</Person>", xml);
        }
    }
}
