namespace ErrorLogApi.Exceptions
{
    using System;

    public class GlobalApplicationException : Exception
    {
        public GlobalApplicationException()
            : base() { }

        public GlobalApplicationException(string message)
            : base(message) { }

        public GlobalApplicationException(string message, Exception innerExceptio)
            : base(message, innerExceptio) { }
    }
}
