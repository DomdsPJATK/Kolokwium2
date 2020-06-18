using System;
using System.Runtime.Serialization;

namespace Kolokwium2.Exceptions
{
    public class PlayerAlreadyExistException : Exception
    {
        public PlayerAlreadyExistException()
        {
        }

        protected PlayerAlreadyExistException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public PlayerAlreadyExistException(string? message) : base(message)
        {
        }

        public PlayerAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}