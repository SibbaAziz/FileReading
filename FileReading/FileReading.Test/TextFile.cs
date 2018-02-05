using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReading.Reading.Text;

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
    }
}
