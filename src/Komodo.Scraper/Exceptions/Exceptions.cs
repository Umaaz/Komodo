using System;
using System.Runtime.Serialization;

namespace Komodo.Scraper.Exceptions
{
    //
    // For guidelines regarding the creation of new exception types, see
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    // and
    //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    //

    [Serializable]
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException()
        {
        }

        public InvalidUrlException(string message) : base(message)
        {
        }

        public InvalidUrlException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidUrlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException()
        {
        }

        public ConnectionFailedException(string message) : base(message)
        {
        }

        public ConnectionFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConnectionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class FetcherBuildFailedException : Exception
    {
        public FetcherBuildFailedException()
        {
        }

        public FetcherBuildFailedException(string message) : base(message)
        {
        }

        public FetcherBuildFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FetcherBuildFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
