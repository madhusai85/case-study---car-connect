using System;
using CarConnectApp.CustomExceptions;

namespace CarConnectApp.CustomExceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
