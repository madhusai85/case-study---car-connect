using NUnit.Framework;
using CarConnectApp.DAO.Implementation;
using CarConnectApp.Entity;
using System;

namespace CarConnectApp.UnitTests
{
    public class CustomerServiceTests
    {
        private CustomerService service;

        [SetUp]
        public void Init()
        {
            service = new CustomerService();
        }

        [Test]
        public void RegisterCustomer_ShouldStoreAndReturnSameEmail()
        {
            string username = "test_" + Guid.NewGuid().ToString("N").Substring(0, 6);
            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@gmail.com",
                PhoneNumber = "9876543210",
                Address = "Vizag",
                Username = username,
                Password = "pass123",
                RegistrationDate = DateTime.Now
            };

            service.RegisterCustomer(customer);
            var result = service.GetCustomerByUsername(username);

            Assert.AreEqual("testuser@gmail.com", result.Email);
        }
    }
}

