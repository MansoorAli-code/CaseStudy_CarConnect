using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using CarConnect.Service;

using System;

namespace CarConnect
{
    internal class Program
    {
        static IAdminService adminService = new AdminService();
        static ICustomerService customerService = new CustomerService();
        static IReservationService reservationService = new ReservationService();
        static IVehicleService vehicleService = new VehicleService();
        static void Main()
        {

            Console.WriteLine("Welcome to Car connect, A car rental platform");

            Console.WriteLine("Please select your role:");
            Console.WriteLine("1. Customer");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Guest");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Your choice: ");
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
        #region ui
        //        Console.ReadKey();
        //        Console.Clear();


        //    Label:
        //        string menu = @"
        //    ╔════════════════════════════════════════════════════════════════════════╗
        //    ║               Menu: Choose an Option by Entering the Number               ║
        //    ║                                                                        ║
        //    ║   1. Customer                                                          ║
        //    ║   2. Vehicle                                                           ║
        //    ║   3. Reservation                                                       ║
        //    ║   4. Admin                                                             ║
        //    ║   5. Exit                                                              ║
        //    ║                                                                        ║
        //    ╚════════════════════════════════════════════════════════════════════════╝";

        //        Console.WriteLine(menu);
        //        Console.Write("Enter Your Choice: ");

        //        int choice = int.Parse(Console.ReadLine());
        //        Console.Clear();
        //        switch (choice)
        //        {
        //            case 1:
        //                //Authentication(Password)
        //                ICustomerRepository icustomerRepository = new CustomerRepository();
        //                Console.WriteLine("To Login");
        //                Console.WriteLine("Enter  Username: ");
        //                string enteredUsername = Console.ReadLine();
        //                Console.WriteLine("Enter Password: ");
        //                string enteredPassword = Console.ReadLine();
        //                bool ans = customerService.AuthenticateCustomer(enteredUsername, enteredPassword);
        //                Console.Clear();
        //                if (!ans)
        //                {
        //                    goto Label;
        //                }
        //                else
        //                {
        //                    string option = @"
        //                           Press1::'GetAllCustomer'
        //                           Press2::'GetAllCustomerByID'
        //                           Press3::'GetCustomerByUsername'
        //                           Press4::'RegisterCustomer'
        //                           Press5::'UpdateCustomer'
        //                           Press6::'RemoveCustomer'";
        //                    Console.WriteLine(option);
        //                    Console.WriteLine("Enter Your Choice::");
        //                    int cho = int.Parse(Console.ReadLine());
        //                    Console.Clear();
        //                    switch (cho)
        //                    {
        //                        case 1://GetAllCustomer

        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;

        //                        case 2:// GetAllCustomerByID
        //                            try
        //                            {
        //                                Console.WriteLine("Enter the CustomerID:");
        //                                int cust_ID = int.Parse(Console.ReadLine());
        //                                Customer customerByID = customerService.GetCustomerById(cust_ID);

        //                                if (customerByID != null)
        //                                {
        //                                    Console.WriteLine(customerByID);
        //                                    Console.ReadKey();
        //                                    Console.Clear();
        //                                    goto Label;
        //                                }
        //                                else
        //                                {
        //                                    throw new CustomerNotFoundException("Customer not found");
        //                                }
        //                            }
        //                            catch (CustomerNotFoundException ex)
        //                            {
        //                                Console.WriteLine($"Error:{ex.Message}");
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            break;

        //                        case 3://GetCustomerByUsername
        //                            try
        //                            {
        //                                Console.WriteLine("Enter the Username:");
        //                                string user_name = Console.ReadLine();
        //                                Customer customerByusername = customerService.GetCustomerByUsername(user_name);
        //                                if (customerByusername != null)
        //                                {
        //                                    Console.WriteLine(customerByusername.ToString());
        //                                    Console.ReadKey();
        //                                    Console.Clear();
        //                                    goto Label;
        //                                }
        //                                else
        //                                {
        //                                    throw new CustomerNotFoundException("Customer not found");

        //                                }
        //                            }
        //                            catch (CustomerNotFoundException ex)
        //                            {
        //                                Console.WriteLine($"Error:{ex.Message}");
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            break;
        //                        case 4://Register Customer
        //                            ICustomerRepository customerRepository = new CustomerRepository();
        //                            Console.WriteLine("To Register Customer");
        //                            Console.WriteLine("Enter the First Name:");
        //                            string FN = Console.ReadLine();
        //                            Console.WriteLine("Enter the Last Name:");
        //                            string LN = Console.ReadLine();
        //                            Console.WriteLine("Enter the Email:");
        //                            string email = Console.ReadLine();
        //                            Console.WriteLine("Enter the PhoneNumber:");
        //                            string pn = Console.ReadLine();
        //                            Console.WriteLine("Enter the Address:");
        //                            string ad = Console.ReadLine();
        //                            Console.WriteLine("Enter the UserName:");
        //                            string un = Console.ReadLine();
        //                            Console.WriteLine("Enter the Password:");
        //                            string pw = Console.ReadLine();
        //                            Customer customer = new Customer
        //                            {
        //                                FirstName = FN,
        //                                LastName = LN,
        //                                Email = email,
        //                                PhoneNumber = pn,
        //                                Address = ad,
        //                                Password = pw,
        //                                RegistrationDate = DateTime.Now
        //                            };
        //                            customerRepository.RegisterCustomer(customer);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                            break;
        //                        case 5:// Update
        //                            Console.WriteLine("Enter Customer ID:");
        //                            int enterID = int.Parse(Console.ReadLine());
        //                            Console.WriteLine("Enter the Email to be updated:");
        //                            string enterMail = Console.ReadLine();
        //                            icustomerRepository.UpdateCustomer(enterID, enterMail);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                            break;

        //                        case 6:// DeleteCustomer
        //                            Console.WriteLine("Enter Customer ID which has to be deleted:");
        //                            int cust_id = int.Parse(Console.ReadLine());
        //                            icustomerRepository.DeleteCustomer(cust_id);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                            break;

        //                        default: goto Label;

        //                    }

        //                }
        //                break;
        //            case 2:
        //                IVehicleRepository ivehicleReposiory = new VehicleRepository();
        //                string opt = @"
        //                           Press1::'GetAllVehicles'
        //                           Press2::'GetVehicleByID'
        //                           Press3::'GetAvailableVehicles'
        //                           Press4::'AddVehicle'
        //                           Press5::'UpdateVehicle'
        //                           Press6::'RemoveVehicle'";
        //                Console.WriteLine(opt);
        //                Console.WriteLine("Enter Your Choice::");
        //                int choi = int.Parse(Console.ReadLine());
        //                Console.Clear();
        //                switch (choi)
        //                {
        //                    case 1: //Get All Vehicles
        //                        List<Vehicle> allVehicles = ivehicleReposiory.GetAllVehicles();
        //                        foreach (var item in allVehicles)
        //                        {
        //                            Console.WriteLine(item);
        //                        }
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 2://Get VehicleByID

        //                        try
        //                        {
        //                            Console.WriteLine("Enter Vehicle ID:");
        //                            int vehicle_id = int.Parse(Console.ReadLine());
        //                            var vehicleById = ivehicleReposiory.GetVehicleById(vehicle_id);
        //                            if (vehicleById != null)
        //                            {
        //                                Console.WriteLine(vehicleById.ToString());
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            else
        //                            {
        //                                throw new VehicleNotFoundException($"Vehicle ID:{vehicle_id} not found");
        //                            }
        //                        }
        //                        catch (VehicleNotFoundException e)
        //                        {
        //                            Console.WriteLine($"Error : {e.Message}");
        //                        }
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;

        //                    case 3: //Get Available Vehicles

        //                        List<Vehicle> availableVehicles = ivehicleReposiory.GetAvailableVehicles();
        //                        foreach (var item in availableVehicles)
        //                        {
        //                            Console.WriteLine(item);
        //                        }
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 4://AddVehicle
        //                        IVehicleRepository vehicleRepository = new VehicleRepository();
        //                        Console.WriteLine("To Add Vehicle");
        //                        Console.WriteLine("Enter the Model Name:");
        //                        string ml = Console.ReadLine();
        //                        Console.WriteLine("Enter the Make:");
        //                        string mk = Console.ReadLine();
        //                        Console.WriteLine("Enter the Year:");
        //                        int yr = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the Color:");
        //                        string cr = Console.ReadLine();
        //                        Console.WriteLine("Enter the  RegistrationNumber:");
        //                        string rn = Console.ReadLine();
        //                        Console.WriteLine("Enter the  Availability(true/false):");
        //                        bool av = bool.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the  DailyRate:");
        //                        float dr = float.Parse(Console.ReadLine());
        //                        Vehicle vehicle = new Vehicle
        //                        {
        //                            Model = ml,
        //                            Make = mk,
        //                            Year = yr,
        //                            Color = cr,
        //                            RegistrationNumber = rn,
        //                            Availability = av,
        //                            DailyRate = dr
        //                        };
        //                        vehicleRepository.AddVehicle(vehicle);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 5://Update
        //                        Console.WriteLine("Enter Vehicle ID:");
        //                        int enteredVehicleID = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the Color to be updated:");
        //                        string enteredColor = Console.ReadLine();
        //                        ivehicleReposiory.UpdateVehicle(enteredVehicleID, enteredColor);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 6://Remove Vehicle
        //                        Console.WriteLine("Enter Vehicle ID to be deleted:");
        //                        int vehi_id = int.Parse(Console.ReadLine());
        //                        ivehicleReposiory.RemoveVehicle(vehi_id);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    default:
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;

        //                }
        //                break;
        //            case 3:
        //                IReservationRepository ireservationRepository = new ReservationRepository();
        //                string opti = @"
        //                           Press1::'CalculateTotalCost'
        //                           Press2::'GetAllReservation'
        //                           Press3::'GetReservationByID'
        //                           Press4::'GetReservationsByCustomerId'
        //                           Press5::'CreateReservation'
        //                           Press6::'UpdateReservation'
        //                           Press7::'CancelReservation'";
        //                Console.WriteLine(opti);
        //                Console.WriteLine("Enter Your Choice::");
        //                int choic = int.Parse(Console.ReadLine());
        //                Console.Clear();
        //                switch (choic)
        //                {
        //                    case 1://CalculateTotalCost
        //                        Console.WriteLine("Enter the Vehicle Id=");
        //                        int vehi_id = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the Reservation Id=");
        //                        int rese_id = int.Parse(Console.ReadLine());
        //                        double? totalcost = ireservationRepository.CalculateTotalCost(vehi_id, rese_id);
        //                        Console.WriteLine($"Total cost for Vehicle Id:{vehi_id}  and  Reservation Id:{rese_id} is {totalcost}");
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 2:
        //                        //Get All Reservations
        //                        List<Reservation> allReservations = ireservationRepository.GetAllReservations();

        //                        foreach (var item in allReservations)
        //                        {
        //                            Console.WriteLine(item);
        //                        }
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 3:// GetReservationById
        //                        try
        //                        {
        //                            Console.WriteLine("Enter Reservation ID:");
        //                            int reservation_id = int.Parse(Console.ReadLine());
        //                            var reservationById = ireservationRepository.GetReservationById(reservation_id);
        //                            if (reservationById != null)
        //                            {
        //                                Console.WriteLine(reservationById.ToString());
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            else
        //                            {
        //                                throw new ReservationNotFoundException($"Reservation not found");
        //                            }
        //                        }
        //                        catch (ReservationNotFoundException ex)
        //                        {
        //                            Console.WriteLine($"Error : {ex.Message}");
        //                        }
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 4:// GetReservationByCustomerId

        //                        try
        //                        {
        //                            Console.WriteLine("Enter Customer ID:");
        //                            int customer_id = int.Parse(Console.ReadLine());
        //                            var reservationByCustomerId = ireservationRepository.GetReservationsByCustomerId(customer_id);
        //                            if (reservationByCustomerId != null)
        //                            {
        //                                Console.WriteLine(reservationByCustomerId.ToString());
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            else
        //                            {
        //                                throw new ReservationNotFoundException($"Customer ID:{customer_id} not found");
        //                            }
        //                        }
        //                        catch (ReservationNotFoundException ex)
        //                        {
        //                            Console.WriteLine($"Error : {ex.Message}");
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                        }
        //                    case 5:
        //                        //CreateReservation
        //                        IReservationRepository reservationRepository = new ReservationRepository();
        //                        Console.WriteLine("To Create reservation");
        //                        Console.WriteLine("Enter the CustomerID: ");
        //                        int cid = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the VehicleID: ");
        //                        int vid = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the StartDate: ");
        //                        DateTime sd = DateTime.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the EndDate: ");
        //                        DateTime ed = DateTime.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the TotalCost: ");
        //                        float tc = float.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the Status: ");
        //                        string sts = Console.ReadLine();
        //                        Reservation reservation = new Reservation
        //                        {
        //                            CustomerID = cid,
        //                            VehicleID = vid,
        //                            StartDate = sd,
        //                            EndDate = ed,
        //                            TotalCost = tc,
        //                            Status = sts
        //                        };
        //                        reservationRepository.CreateReservation(reservation);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;

        //                    case 6://update
        //                        Console.WriteLine("Enter Reservation ID:");
        //                        int enteredReservationID = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter the Status to be updated:");
        //                        string enteredStatus = Console.ReadLine();
        //                        ireservationRepository.UpdateReservation(enteredReservationID, enteredStatus);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    case 7://Delete Reservation
        //                        Console.WriteLine("Enter Reservation ID that has to be deleted:");
        //                        int r_id = int.Parse(Console.ReadLine());
        //                        ireservationRepository.CancelReservation(r_id);
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                    default:
        //                        Console.ReadKey();
        //                        Console.Clear();
        //                        goto Label;
        //                }
        //                break;
        //            case 4://Authentication(Password)
        //                IAdminRepository iadminRepository = new AdminRepository();
        //                Console.WriteLine("To Login");
        //                Console.WriteLine("Enter Admin username:");
        //                string u = Console.ReadLine();
        //                Console.WriteLine("Enter Admin password:");
        //                string p = Console.ReadLine();
        //                int ans1 = iadminRepository.Authenticate(u, p);
        //                Console.Clear();
        //                if (ans1 != 1)
        //                {
        //                    goto Label;
        //                }
        //                else
        //                {
        //                    string option = @"
        //                           Press1::'GetAllAdmin'
        //                           Press2::'GetAdminById'
        //                           Press3::'GetAdminByUserName'
        //                           Press4::'RegisterAdmin'
        //                           Press5::'UpdateAdmin'
        //                           Press6::'DeleteAdmin'";
        //                    Console.WriteLine(option);
        //                    Console.WriteLine("Enter Your Choice::");
        //                    int choicee = int.Parse(Console.ReadLine());
        //                    Console.Clear();
        //                    switch (choicee)
        //                    {
        //                        case 1://GetAllAdmin
        //                            List<Admin> alladmins = iadminRepository.GetAllAdmin();
        //                            foreach (var item in alladmins)
        //                            {
        //                                Console.WriteLine(item);
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            break;
        //                        case 2://#region GetAdminById
        //                            try
        //                            {
        //                                Console.WriteLine("Enter Admin ID:");
        //                                int a_id = int.Parse(Console.ReadLine());
        //                                var adminById = iadminRepository.GetAdminById(a_id);
        //                                if (adminById != null)
        //                                {
        //                                    Console.WriteLine(adminById);
        //                                    Console.ReadKey();
        //                                    Console.Clear();
        //                                    goto Label;
        //                                }
        //                                else
        //                                {
        //                                    throw new AdminNotFoundException($"Admin ID: {a_id} not found");

        //                                }
        //                            }
        //                            catch (AdminNotFoundException ex)
        //                            {
        //                                Console.WriteLine($"Error : {ex.Message}");
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            break;
        //                        case 3://Get Admin by UserName

        //                            try
        //                            {
        //                                Console.WriteLine("Enter Admin UserName:");
        //                                string user = (Console.ReadLine());
        //                                var adminByUserName = iadminRepository.GetAdminByUserName(user);
        //                                if (adminByUserName != null)
        //                                {
        //                                    Console.WriteLine(adminByUserName);
        //                                    Console.ReadKey();
        //                                    Console.Clear();
        //                                    goto Label;
        //                                }
        //                                else
        //                                {
        //                                    throw new AdminNotFoundException($"UserName: {user} not found");
        //                                }
        //                            }
        //                            catch (AdminNotFoundException ex)
        //                            {
        //                                Console.WriteLine($"Error : {ex.Message}");
        //                                Console.ReadKey();
        //                                Console.Clear();
        //                                goto Label;
        //                            }
        //                            break;
        //                        case 4://Register Admin
        //                            Console.WriteLine("To Register Admin");
        //                            Console.WriteLine("Enter the First Name: ");
        //                            string fs = Console.ReadLine();
        //                            Console.WriteLine("Enter the Last Name: ");
        //                            string ls = Console.ReadLine();
        //                            Console.WriteLine("Enter the Email: ");
        //                            string email = Console.ReadLine();
        //                            Console.WriteLine("Enter the PhoneNumber: ");
        //                            string pn = Console.ReadLine();
        //                            Console.WriteLine("Enter the UserName: ");
        //                            string us = Console.ReadLine();
        //                            Console.WriteLine("Enter the Password: ");
        //                            string pw = Console.ReadLine();
        //                            Console.WriteLine("Enter the Role: ");
        //                            string role = Console.ReadLine();
        //                            Admin admin = new Admin
        //                            {
        //                                FirstName = fs,
        //                                LastName = ls,
        //                                Email = email,
        //                                PhoneNumber = pn,
        //                                UserName = us,
        //                                Password = pw,
        //                                Role = role,
        //                                JoinDate = DateTime.Now
        //                            };
        //                            iadminRepository.RegisterAdmin(admin);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                            break;
        //                        case 5:// Update Admin
        //                            Console.WriteLine("Enter Admin ID:");
        //                            int enteredAdminID = int.Parse(Console.ReadLine());
        //                            Console.WriteLine("Enter the First Name to update:");
        //                            string enteredfirstname = Console.ReadLine();
        //                            iadminRepository.UpdateAdmin(enteredAdminID, enteredfirstname);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                        case 6:// Delete Admin

        //                            Console.WriteLine("Enter Admin ID that has to be deleted:");
        //                            int adminid = int.Parse(Console.ReadLine());
        //                            iadminRepository.DeleteAdmin(adminid);
        //                            Console.ReadKey();
        //                            Console.Clear();
        //                            goto Label;
        //                    }
        //                    break;

        //                }
        //            case 5:
        //                Environment.Exit(0);
        //                break;

        //            default:
        //                Console.ReadKey();
        //                Console.Clear();
        //                goto Label;
        //        }

        //    }
        //}
        #endregion

        static void CustomerLogin()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nCustomer Login");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter Your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Customer Login");

                        Console.Write("Enter your username: ");
                        string? username = Console.ReadLine();
                        Console.Write("Enter your password: ");
                        string? password = Console.ReadLine();
                        int id = customerService.AuthenticateCustomer(username, password);
                        if (id!=-1)
                        {
                            Console.WriteLine("Login successful!");
                            CustomerMenu(username,id);
                        }
                        else
                        {
                            Console.WriteLine("Login failed. Invalid credentials.");
                        }
                        break;
                    case 2:
                        customerService.RegisterCustomer();
                        break;
                    case 3:
                        return;
                }
            }
            
        }

        static void AdminLogin()
        {
            
            Console.WriteLine("Admin Login");

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();


            if (adminService.Authenticate(username, password))
            {
                Console.WriteLine("Login successful!");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Login failed. Invalid credentials.");
            }
        }

        static void GuestLogin()
        {
            Console.WriteLine("You have logged in as a guest");
            GuestMenu();
        }

        static void CustomerMenu(string username, int id)
        {
            while (true)
            {
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("1. View Vehicles");
                Console.WriteLine("2. Make a Reservation");
                Console.WriteLine("3. View Reservations");
                Console.WriteLine("4. Logout");
                Console.WriteLine("Enter Your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                switch (choice)
                {
                    case 1:
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
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. Register a new admin");
                Console.WriteLine("2. Update a admin");
                Console.WriteLine("3. Delete an existing admin");
                Console.WriteLine("4. Get all customers");
                Console.WriteLine("5. Update a customer by id");
                Console.WriteLine("6. Delete a customer by id");
                Console.WriteLine("7. Add Vehicle");
                Console.WriteLine("8. Update Vehicle");
                Console.WriteLine("9. Delete Vehicle");
                Console.WriteLine("10. View all Reservations");
                Console.WriteLine("11. Delete a reservation");
                Console.WriteLine("12. Get Total Cost of a reservation");
                Console.WriteLine("13. Generate the reports");
                Console.WriteLine("14. Logout");
                Console.WriteLine("Enter Your choice: ");
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
                        
                        Console.WriteLine("Option 10 selected: View all Reservations");
                        reservationService.GetAllReservations();
                        break;

                    case 11:
                        Console.WriteLine("Option 11 selected: Delete a reservation");
                        reservationService.CancelReservation();
                        break;

                    case 12:
                        Console.WriteLine("Option 12 selected: Get Total Amount of Reservation");
                        reservationService.CalculateTotalCost();
                        break;
                    case 13:
                        

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
    }
}
            
        

