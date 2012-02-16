﻿using Komodo.Scraper.Fetcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Komodo.UnitTest
{
    
    
    /// <summary>
    ///This is a test class for FilmFetcherTest and is intended
    ///to contain all FilmFetcherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FilmFetcherTest
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
        ///A test for GetFilmFromImdb
        ///</summary>
        [TestMethod()]
        public void GetFilmFromImdbTest()
        {
            var title = "Matrix"; // TODO: Initialize to an appropriate value
            var source = FilmFetcher.Source.Imdb; // TODO: Initialize to an appropriate value
            var target = new FilmFetcher(title, source); // TODO: Initialize to an appropriate value
            var title1 = "Matrix"; // TODO: Initialize to an appropriate value
            target.GetFilmFromImdb(title1);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
