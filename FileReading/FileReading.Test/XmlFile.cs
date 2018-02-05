using FileReading.Reading.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
