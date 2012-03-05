using Komodo.Core.Database;
using Komodo.Core.Database.Commands;
using Komodo.Scraper.Fetcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Komodo.Core.Types.Model;

namespace Komodo.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for AddTest and is intended
    ///to contain all AddTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddTest
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
        ///A test for AddFilm
        ///</summary>
        [TestMethod()]
        public void AddFilmTest()
        {
            Context.Bootstrap();
            Film film = new FilmFetcher("Matrix").Film; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Add.AddFilm(film);

            var id = Komodo.Core.Database.Index.Search.Search.SearchFilm("Matrix");
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
