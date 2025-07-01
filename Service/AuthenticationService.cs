using CarConnectApp.DAO.Implementation;
using CarConnectApp.DAO.Interfaces;
using CarConnectApp.Entity;
using CarConnectApp.CustomExceptions;

namespace CarConnectApp.Service
{
    public class AuthenticationService
    {
        private readonly ICustomerService customerService;
        private readonly IAdminService adminService;

        public AuthenticationService()
        {
            customerService = new CustomerService();
            adminService = new AdminService();
        }

        public Customer LoginCustomer(string username, string password)
        {
            Customer customer = customerService.GetCustomerByUsername(username);
            if (customer == null)
                throw new AuthenticationException("Customer not found.");
            if (!customer.Authenticate(password))
                throw new AuthenticationException("Invalid customer password.");
            return customer;
        }

        public Admin LoginAdmin(string username, string password)
        {
            Admin admin = adminService.GetAdminByUsername(username);
            if (admin == null)
                throw new AuthenticationException("Admin not found.");
            if (!admin.Authenticate(password))
                throw new AuthenticationException("Invalid admin password.");
            return admin;
        }
    }
}
