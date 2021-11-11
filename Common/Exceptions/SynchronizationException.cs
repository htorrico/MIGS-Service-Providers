using System;

namespace Common.Exceptions
{
    public class SynchronizationDonwloadException : Exception
    {
        public SynchronizationDonwloadException()
        {
        }

        public SynchronizationDonwloadException(string message)
            : base(message)
        {
        }

        public SynchronizationDonwloadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class SynchronizationUploadException : Exception
    {
        public SynchronizationUploadException()
        {
        }

        public SynchronizationUploadException(string message)
            : base(message)
        {
        }

        public SynchronizationUploadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
