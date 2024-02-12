using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using CarConnect.Service;

using System;
using System.Text;

namespace CarConnect
{
    internal class Program
    {
        static IAdminService adminService = new AdminService();
        static ICustomerService customerService = new CustomerService();
        static IReservationService reservationService = new ReservationService();
        static IVehicleService vehicleService = new VehicleService();
        static IReportService reportService = new ReportService();
        static void Main()
        {

            Console.WriteLine("===============================================");
            Console.WriteLine("          Welcome to Car Connect");
            Console.WriteLine("      Your Premier Car Rental Platform");
            Console.WriteLine("===============================================");
            Console.WriteLine("Please select your role:");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Guest");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            int roleChoice;
            while (!int.TryParse(Console.ReadLine(), out roleChoice) || roleChoice < 1 || roleChoice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }

            switch (roleChoice)
            {
                case 1:
                    CustomerLogin();
                    break;
                case 2:
                    AdminLogin();
                    break;
                case 3:
                    GuestLogin();
                    break;
                case 4:
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
            }
        }

        static void CustomerLogin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════╗");
                Console.WriteLine("║       Customer Login    ║");
                Console.WriteLine("╠════════════════════════╣");
                Console.WriteLine("║ 1. Login                ║");
                Console.WriteLine("║ 2. Register             ║");
                Console.WriteLine("║ 3. Exit                 ║");
                Console.WriteLine("╚════════════════════════╝");
                Console.Write("Enter your choice: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    Console.Write("Enter your choice: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nCustomer Login");
                        Console.Write("Enter your username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string password = GetMaskedInput();
                        int id = customerService.AuthenticateCustomer(username, password);
                        if (id != -1)
                        {
                            Console.WriteLine("\nLogin successful!");
                            CustomerMenu(username, id);
                        }
                        else
                        {
                            Console.WriteLine("\nLogin failed. Invalid credentials.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Customer Registration");
                        customerService.RegisterCustomer();
                        break;
                    case 3:
                        return;
                }
            }
        }

        static string GetMaskedInput()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password.ToString();
        }


        static void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║        Admin Login      ║");
            Console.WriteLine("╚════════════════════════╝");

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = GetMaskedInput();

            if (adminService.Authenticate(username, password))
            {
                Console.WriteLine("\nLogin successful!");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("\nLogin failed. Invalid credentials.");
            }
        }

        static void GuestLogin()
        {
            Console.Clear();
            Console.WriteLine("You have logged in as a guest\n");
            GuestMenu();
        }

        static void CustomerMenu(string username, int id)
        {
            while (true)
            {
                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("║        Customer Menu       ║");
                Console.WriteLine("╠════════════════════════════╣");
                Console.WriteLine("║ 1. View Vehicles           ║");
                Console.WriteLine("║ 2. Make a Reservation      ║");
                Console.WriteLine("║ 3. View Reservations       ║");
                Console.WriteLine("║ 4. Logout                  ║");
                Console.WriteLine("╚════════════════════════════╝");
                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        vehicleService.GetAvailableVehicles();
                        break;
                    case 2:
                        reservationService.CreateReservation(id);
                        break;
                    case 3:
                        reservationService.GetReservationById(id);
                        break;
                    case 4:
                        Console.WriteLine("Logging out");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("╔════════════════════════════╗");
                Console.WriteLine("║          Admin Menu         ║");
                Console.WriteLine("╠════════════════════════════╣");
                Console.WriteLine("║ 1. Register a new admin     ║");
                Console.WriteLine("║ 2. Update an admin          ║");
                Console.WriteLine("║ 3. Delete an existing admin ║");
                Console.WriteLine("║ 4. Get all customers        ║");
                Console.WriteLine("║ 5. Update a customer by id  ║");
                Console.WriteLine("║ 6. Delete a customer by id  ║");
                Console.WriteLine("║ 7. Add Vehicle              ║");
                Console.WriteLine("║ 8. Update Vehicle           ║");
                Console.WriteLine("║ 9. Delete Vehicle           ║");
                Console.WriteLine("║ 10. Delete a reservation    ║");
                Console.WriteLine("║ 11. Generate the reports    ║");
                Console.WriteLine("║ 12. Logout                  ║");
                Console.WriteLine("╚════════════════════════════╝");
                Console.Write("Enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice <0 || choice > 14)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                switch (choice)
                {
                    case 1:
                        
                        Console.WriteLine("Option 1 selected: Register a new admin");
                        adminService.RegisterAdmin();
                        break;

                    case 2:
                        
                        Console.WriteLine("Option 2 selected: Update an admin");
                        adminService.UpdateAdmin();
                        break;

                    case 3:
                        
                        Console.WriteLine("Option 3 selected: Delete an existing admin");
                        adminService.DeleteAdmin();
                        break;

                    case 4:
                        
                        Console.WriteLine("Option 4 selected: Get all customers");
                        customerService.GetAllCustomers();
                        break;

                    case 5:
                        
                        Console.WriteLine("Option 5 selected: Update a customer by id");
                        customerService.UpdateCustomer();
                        break;

                    case 6:
                        
                        Console.WriteLine("Option 6 selected: Delete a customer by id");
                        customerService.deleteCustomer();
                        break;

                    case 7:
                        
                        Console.WriteLine("Option 7 selected: Add Vehicle");
                        vehicleService.AddVehicle();
                        break;

                    case 8:
                        
                        Console.WriteLine("Option 8 selected: Update Vehicle");
                        vehicleService.UpdateVehicle();
                        break;

                    case 9:
                        
                        Console.WriteLine("Option 9 selected: Delete Vehicle");
                        vehicleService.RemoveVehicle();
                        break;

                    case 10:
                        Console.WriteLine("Option 11 selected: Delete a reservation");
                        reservationService.CancelReservation();
                        break;
                    case 11:
                        Console.WriteLine("Option 12 selected: Reports");
                        ReportMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        break;
                }

            }
        }
        

        static void GuestMenu()
        {
            while (true)
            {
                
                Console.WriteLine("\nGuest Menu");
                Console.WriteLine("1. View all vehicle data");
                Console.WriteLine("2. Register as a customer");
                Console.WriteLine("3. Logout");
                Console.WriteLine("Enter Your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                switch (choice)
                {
                    
                    case 1:
                        Console.WriteLine("viewing all vehicle data");
                        vehicleService.GetAvailableVehicles();
                        break;
                    case 2:
                        CustomerLogin();
                        break;
                    case 3:
                        Console.WriteLine("Exiting ");
                        return;
                }
            }
        }
        static void ReportMenu()
        {
            while (true)
            {

                Console.WriteLine("\nReport Menu");
                Console.WriteLine("1. Get Reservation History");
                Console.WriteLine("2. Get Vehicle Utilization Data");
                Console.WriteLine("3. Get Revenue Data");
                Console.WriteLine("4. Logout");
                Console.WriteLine("Enter Your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                switch (choice)
                {

                    case 1:
                        reportService.GetReservationHistory();
                        break;
                    case 2:
                        reportService.GetVehicleUtilizationData();
                        break;
                    case 3:
                        reportService.GetRevenueData();
                        break;
                    case 4:
                        Console.WriteLine("Exiting ");
                        return;
                }
            }
        }
    }
}
            
        

