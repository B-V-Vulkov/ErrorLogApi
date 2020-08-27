namespace ErrorLogApi.Exceptions
{
    using System;

    using static ExceptionMessages;

    public class InvalidUsernameOrPasswordException : GlobalApplicationException
    {
        public InvalidUsernameOrPasswordException()
            : base(InvalidUsernameOrPasswordExceptionMessage) { }

        public InvalidUsernameOrPasswordException(string message)
            : base(message) { }

        public InvalidUsernameOrPasswordException(string message, Exception innerExceptio)
            : base(message, innerExceptio) { }
    }
}
