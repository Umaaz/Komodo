using Komodo.App.Contorllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for SettingsControllerTest and is intended
    ///to contain all SettingsControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SettingsControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AddFileExtension
        ///</summary>
        [TestMethod()]
        public void AddFileExtensionTest()
        {
            const string extension = "*.asdf";
            var actual = SettingsController.AddFileExtension(extension);
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void AddFileExtensionTestFail()
        {
            const string extension = "*.asdf\a";
            var actual = SettingsController.AddFileExtension(extension);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void RemoveFileExtentionTestPass()
        {
            const string extension = "*.asdf";
            var actual = SettingsController.AddFileExtension(extension);
            Assert.AreEqual(true, actual);
        }
        
        [TestMethod]
        public void RemoveFileExtentionTestFail()
        {
            const string extension = "*.asdf\a";
            var actual = SettingsController.AddFileExtension(extension);
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for AddWatchedFolders
        ///</summary>
        [TestMethod()]
        public void AddWatchedFoldersTest()
        {
            var folder = "C:/films";
            var actual = SettingsController.AddWatchedFolders(folder);
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        ///A test for RemoveWatchedFolders
        ///</summary>
        [TestMethod()]
        public void RemoveWatchedFoldersTest()
        {
            var folder = "C:/films"; 
            var actual = SettingsController.RemoveWatchedFolders(folder);
            Assert.AreEqual(true, actual);
        }
    }
}
