using System;
using CarConnectApp.CustomExceptions;

namespace CarConnectApp.CustomExceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException(string message) : base(message) { }
    }
}
