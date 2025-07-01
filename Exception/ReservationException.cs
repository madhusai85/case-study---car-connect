using System;
using CarConnectApp.CustomExceptions;
namespace CarConnectApp.CustomExceptions
{
    public class ReservationException : Exception
    {
        public ReservationException(string message) : base(message) { }
    }
}
