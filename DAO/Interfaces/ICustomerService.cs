using CarConnectApp.Entity;

namespace CarConnectApp.DAO.Interfaces
{
    public interface ICustomerService
    {
        void RegisterCustomer(Customer customer);
        Customer GetCustomerById(int id);
        Customer GetCustomerByUsername(string username);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
