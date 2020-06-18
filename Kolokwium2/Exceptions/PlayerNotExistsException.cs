using System;
using System.Runtime.Serialization;

namespace Kolokwium2.Exceptions
{
    public class PlayerNotExistsException : Exception
    {
        public PlayerNotExistsException()
        {
        }

        protected PlayerNotExistsException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public PlayerNotExistsException(string? message) : base(message)
        {
        }

        public PlayerNotExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}