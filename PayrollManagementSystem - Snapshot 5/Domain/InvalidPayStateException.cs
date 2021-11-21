using System;
using System.Runtime.Serialization;

namespace Domain
{
    public class InvalidPayStateException : Exception
    {
        public InvalidPayStateException(string message) : base(message) { }
    }
}