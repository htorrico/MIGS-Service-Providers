using System;

namespace Common.Exceptions
{
    public class NoAvailableOfflineException : Exception
    {
        public NoAvailableOfflineException()
        {
        }

        public NoAvailableOfflineException(string message)
            : base(message)
        {
        }

        public NoAvailableOfflineException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}