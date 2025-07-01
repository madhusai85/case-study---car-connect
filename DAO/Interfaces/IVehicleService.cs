using System.Collections.Generic;
using CarConnectApp.Entity;

namespace CarConnectApp.DAO.Interfaces
{
    public interface IVehicleService
    {
        void AddVehicle(Vehicle vehicle);
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetAvailableVehicles();
        void UpdateVehicle(Vehicle vehicle);
        void RemoveVehicle(int vehicleId);
    }
}
