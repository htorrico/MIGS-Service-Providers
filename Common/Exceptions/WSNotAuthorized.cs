using System;

namespace Common.Exceptions
{
    /// <summary>
    /// Catch NotAuthorized Exception into WebServices
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class WSNotAuthorized : Exception
    {
        public WSNotAuthorized()
        {
        }

        public WSNotAuthorized(string message)
            : base(message)
        {
        }

        public WSNotAuthorized(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}