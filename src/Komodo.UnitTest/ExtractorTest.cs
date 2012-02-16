using Komodo.Scraper.StringManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for ExtractorTest and is intended
    ///to contain all ExtractorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExtractorTest
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
        ///A test for Extract
        ///</summary>
        [TestMethod()]
        public void ExtractTest()
        {
            string expression = "<a href=\"/title/{X}/\" title=\"{X}({X})\"><img src=\"{X}\" height=\"[0-9]*\" width=\"[0-9]*\" alt=\"[^\"]*\" title=\"[^\"]*\"></a>";
            string value = "<a href=\"/title/tt0133093/\" title=\"The Matrix (1999)\"><img src=\"http://ia.media-imdb.com/images/M/MV5BMjEzNjg1NTg2NV5BMl5BanBnXkFtZTYwNjY3MzQ5._V1._SX54_CR0,0,54,74_.jpg\" height=\"74\" width=\"54\" alt=\"The Matrix (1999)\" title=\"The Matrix (1999)\"></a>";
            string[] expected = {"tt0133093","The Matrix","1999","http://ia.media-imdb.com/images/M/MV5BMjEzNjg1NTg2NV5BMl5BanBnXkFtZTYwNjY3MzQ5._V1._SX54_CR0,0,54,74_.jpg"};
            string[] actual, actual2;
            actual = Extractor.Extract(expression, value);
            Assert.AreEqual(expected.ToString(),actual.ToString());
        }
    }
}
