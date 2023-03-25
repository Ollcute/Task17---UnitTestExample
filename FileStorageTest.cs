using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Reflection;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for FileStorageTest
    /// </summary>
    [TestClass]
    public class FileStorageTest
    {
        public const string MAX_SIZE_EXCEPTION = "DIFFERENT MAX SIZE";
        public const string NULL_FILE_EXCEPTION = "NULL FILE";
        public const string NO_EXPECTED_EXCEPTION_EXCEPTION = "There is no expected exception";

        public const string SPACE_STRING = " ";
        public const string NAME_STRING = "TXT.txt";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public const string REPEATED_STRING = "AA";
        public const string WRONG_SIZE_CONTENT_STRING = "TEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtext";
        public const string TIC_TOC_TOE_STRING = "tictoctoe.game";

        public const int NEW_SIZE = 5;

        public FileStorage storage = new FileStorage(NEW_SIZE);
        public File file = new File(NAME_STRING, CONTENT_STRING);

        /* ПРОВАЙДЕРЫ */

        static object[] NewFilesData =
        {
            new object[] { new File(REPEATED_STRING, CONTENT_STRING) },
            new object[] { new File(SPACE_STRING, WRONG_SIZE_CONTENT_STRING) },
            new object[] { new File(FILE_PATH_STRING, CONTENT_STRING) }
        };

        static object[] FilesForDeleteData =
        {
            new object[] { new File(REPEATED_STRING, CONTENT_STRING), REPEATED_STRING },
            new object[] { null, TIC_TOC_TOE_STRING }
        };

        static object[] NewExceptionFileData = {
            new object[] { new File(REPEATED_STRING, CONTENT_STRING) }
        };

        /* Тестирование записи файла */
        
          [TestMethod]
            public void WriteTest(){ 
            // Act
            var result = storage.Write(file);
            // Assert
            Assert.IsTrue(result);
            }
        

        /* Тестирование записи дублирующегося файла */
        [TestMethod]
        public void WriteExceptionTest() {
            // Arrange
            storage.Write(file);
            // Act & Assert
            Assert.Throws<FileNameAlreadyExistsException>(() => storage.Write(file));
        }

        /* Тестирование проверки существования файла */
        [TestMethod]
        public void IsExistsTest() {
            // Arrange
            storage.Write(file);
            // Act
            bool result = storage.IsExists("non_existing_file");
            // Assert
            Assert.IsFalse(result);
        }
       
       
        /* Тестирование удаления файла */
        [TestMethod]
        public void DeleteTest() {
            // Arrange
            storage.Write(file);
            // Act
            var result = storage.Delete(NAME_STRING);
            // Assert
            Assert.True(result);
        }

        /* Тестирование получения файлов */
        [TestMethod]
        public void GetFilesTest()
        {
            foreach (File el in storage.GetFiles()) 
            {
                Assert.NotNull(el);
            }
        }
        
        
        /* Тестирование получения файла */
        [TestMethod]
        public void GetFileTest() 
        {
            // Act
            string actualName = file.GetFilename();

            // Assert
            Assert.AreEqual(NAME_STRING, actualName,CONTENT_STRING);
        }
        //+тестирование метода FileStorage(int size) с проверкой максимального размера
        [TestMethod]
        public void TestConstructorWithSize()
        {   // Arrange
            int size = 50;
            FileStorage fileStorage = new FileStorage(size);
            // Assert
            Assert.AreEqual(size, fileStorage.maxSize);
            Assert.AreEqual(size + 100, fileStorage.availableSize);
        }
       


    }
}
