using System;
using CarConnectApp.Entity;
using CarConnectApp.DAO.Interfaces;
using CarConnectApp.DAO.Implementation;
using CarConnectApp.Service;
using CarConnectApp.CustomExceptions;
using CarConnectApp.Service;
using CarConnectApp.Util;
using CarConnectApp.Entity;




namespace CarConnectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthenticationService authService = new AuthenticationService();
            ICustomerService customerService = new CustomerService();
            IAdminService adminService = new AdminService();
            IVehicleService vehicleService = new VehicleService();
            IReservationService reservationService = new ReservationService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CarConnect Rental System ===");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. Customer Login");
                Console.WriteLine("3. Register as Customer");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Admin Username: ");
                            string adminUser = Console.ReadLine();
                            Console.Write("Password: ");
                            string adminPass = Console.ReadLine();
                            Admin admin = authService.LoginAdmin(adminUser, adminPass);
                            AdminMenu(admin, vehicleService);
                            break;

                        case "2":
                            Console.Write("Customer Username: ");
                            string custUser = Console.ReadLine();
                            Console.Write("Password: ");
                            string custPass = Console.ReadLine();
                            Customer customer = authService.LoginCustomer(custUser, custPass);
                            CustomerMenu(customer, vehicleService, reservationService);
                            break;

                        case "3":
                            Customer newCustomer = new Customer();
                            Console.Write("First Name: ");
                            newCustomer.FirstName = Console.ReadLine();
                            Console.Write("Last Name: ");
                            newCustomer.LastName = Console.ReadLine();
                            Console.Write("Email: ");
                            newCustomer.Email = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            newCustomer.PhoneNumber = Console.ReadLine();
                            Console.Write("Address: ");
                            newCustomer.Address = Console.ReadLine();
                            Console.Write("Username: ");
                            newCustomer.Username = Console.ReadLine();
                            Console.Write("Password: ");
                            newCustomer.Password = Console.ReadLine();
                            newCustomer.RegistrationDate = DateTime.Now;

                            customerService.RegisterCustomer(newCustomer);
                            Console.WriteLine("✅ Registration successful.");
                            break;

                        case "4":
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("❌ Invalid choice.");
                            break;
                    }
                }
                catch (AuthenticationException ex)
                {
                    Console.WriteLine($"❌ Login failed: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to return to main menu...");
                Console.ReadLine();
            }
        }

        static void AdminMenu(Admin admin, IVehicleService vehicleService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, Admin {admin.FirstName}");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Vehicle vehicle = new Vehicle();
                        Console.Write("Model: ");
                        vehicle.Model = Console.ReadLine();
                        Console.Write("Make: ");
                        vehicle.Make = Console.ReadLine();
                        Console.Write("Year: ");
                        vehicle.Year = int.Parse(Console.ReadLine());
                        Console.Write("Color: ");
                        vehicle.Color = Console.ReadLine();
                        Console.Write("Registration Number: ");
                        vehicle.RegistrationNumber = Console.ReadLine();
                        Console.Write("Daily Rate: ");
                        vehicle.DailyRate = decimal.Parse(Console.ReadLine());
                        vehicle.Availability = true;

                        vehicleService.AddVehicle(vehicle);
                        Console.WriteLine("✅ Vehicle added successfully!");
                        break;

                    case "2":
                        return;

                    default:
                        Console.WriteLine("❌ Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void CustomerMenu(Customer customer, IVehicleService vehicleService, IReservationService reservationService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {customer.FirstName}");
                Console.WriteLine("1. View Available Vehicles");
                Console.WriteLine("2. Book a Vehicle");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var vehicles = vehicleService.GetAvailableVehicles();
                        Console.WriteLine("Available Vehicles:");
                        foreach (var v in vehicles)
                        {
                            Console.WriteLine($"ID: {v.VehicleID}, {v.Make} {v.Model}, ₹{v.DailyRate}/day");
                        }
                        break;

                    case "2":
                        Reservation reservation = new Reservation();
                        reservation.CustomerID = customer.CustomerID;
                        Console.Write("Enter Vehicle ID: ");
                        reservation.VehicleID = int.Parse(Console.ReadLine());
                        Console.Write("Start Date (yyyy-mm-dd): ");
                        reservation.StartDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("End Date (yyyy-mm-dd): ");
                        reservation.EndDate = DateTime.Parse(Console.ReadLine());
                        reservation.Status = "Booked";

                        Vehicle selectedVehicle = vehicleService.GetVehicleById(reservation.VehicleID);
                        reservation.CalculateTotalCost(selectedVehicle.DailyRate);

                        reservationService.BookReservation(reservation);
                        Console.WriteLine("✅ Reservation confirmed.");
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("❌ Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
