using System;

namespace Common.Exceptions
{
    public class NoAvailableOnlineException : Exception
    {
        public NoAvailableOnlineException()
        {
        }

        public NoAvailableOnlineException(string message)
            : base(message)
        {
        }

        public NoAvailableOnlineException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}