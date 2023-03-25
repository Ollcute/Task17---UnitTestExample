using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;


namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;
        public string[] CONTENT = { "Hello World!" , "Hello Olesia"};
     
        /* ПРОВАЙДЕР */
        File[] FilesData =
        {
            new File(FILE_PATH_STRING, CONTENT_STRING),
            new File(SPACE_STRING, SPACE_STRING)
        };

        /* Тестируем получение размера */
        [TestMethod]
        public void GetSizeTest()
        {
            foreach(File file in FilesData)
            {
                lenght = file.getContent().Length / 2;

                Assert.AreEqual(file.GetSize(),lenght, SIZE_EXCEPTION);
            }
            
        }
        [TestMethod]
        public void GetFilenameTest()
        {
            // Arrange
            File file = new File(NAME_EXCEPTION, CONTENT_STRING);
            // Act
            string actualFilename = file.GetFilename();
            // Assert
            Assert.AreEqual(NAME_EXCEPTION, actualFilename);
        }
        //+ тестируем получение содержимого файла
        [TestMethod]
        public void TestGetContent()
        {
            // Act
            File file = new File(NAME_EXCEPTION, CONTENT_STRING);
            // Assert
            Assert.AreEqual(CONTENT_STRING, file.getContent());
        }
        //+ тестируем получение правильного расширения файла
        [TestMethod]
        public void TestGetExtension()
        {   string extension = NAME_EXCEPTION.Split('.')[NAME_EXCEPTION.Split('.').Length - 1];
            // Act
            File file = new File(NAME_EXCEPTION,extension);
            // Assert
            Assert.AreEqual(NAME_EXCEPTION, file.GetExtension());
        }


    }
}
