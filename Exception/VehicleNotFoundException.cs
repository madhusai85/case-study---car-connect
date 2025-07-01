using System;
using CarConnectApp.CustomExceptions;

namespace CarConnectApp.CustomExceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(string message) : base(message) { }
    }
}
