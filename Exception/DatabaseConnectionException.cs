using System;
using CarConnectApp.CustomExceptions;


namespace CarConnectApp.CustomExceptions
{
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
    }
}
