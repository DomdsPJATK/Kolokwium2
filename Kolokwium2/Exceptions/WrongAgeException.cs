using System;
using System.Runtime.Serialization;

namespace Kolokwium2.Exceptions
{
    public class WrongAgeException : Exception
    {
        public WrongAgeException()
        {
        }

        protected WrongAgeException(SerializationInfo? info, StreamingContext context) : base(info, context)
        {
        }

        public WrongAgeException(string? message) : base(message)
        {
        }

        public WrongAgeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}