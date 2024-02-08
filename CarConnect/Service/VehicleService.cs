using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    public class VehicleService : IVehicleService
    {
        readonly IVehicleRepository _vehicleRepository;
        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        public void AddVehicle()
        {
            try
            {
                Vehicle newVehicle = new Vehicle();

                Console.WriteLine("Id: ");
                newVehicle.VehicleID = int.Parse(Console.ReadLine());

                Console.WriteLine("Model: ");
                newVehicle.Model = Console.ReadLine();

                Console.WriteLine("Make: ");
                newVehicle.Make = Console.ReadLine();

                Console.WriteLine("Year: ");
                newVehicle.Year = int.Parse(Console.ReadLine());

                Console.WriteLine("Color: ");
                newVehicle.Color = Console.ReadLine();

                Console.WriteLine("Registration Number: ");
                newVehicle.RegistrationNumber = Console.ReadLine();

                Console.WriteLine("Availability (true/false): ");
                if (bool.TryParse(Console.ReadLine(), out bool availability))
                {
                    newVehicle.Availability = availability;
                }
                else
                {
                    throw new InvalidDataException("Invalid input for Availability. Please enter true or false.");

                }

                Console.Write("Daily Rate: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal dailyRate))
                {
                    newVehicle.DailyRate = dailyRate;
                }
                else
                {
                    throw new InvalidDataException("Invalid input for Daily Rate. Please enter a valid decimal number.");
                }

                if (_vehicleRepository.AddVehicle(newVehicle))
                {
                    Console.WriteLine("Vehicle added successfully");
                }
                else
                {
                    Console.WriteLine("Vehicle not added");
                }
            }catch(InvalidDataException ide)
            {
                Console.WriteLine(ide.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAvailableVehicles()
        {
            List<Vehicle> vehicles = _vehicleRepository.GetAvailableVehicles();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        

        public void RemoveVehicle()
        {
            try
            {
                Console.Write("Enter the Vehicle ID: ");
                int vehicleId = int.Parse(Console.ReadLine());

                if (_vehicleRepository.RemoveVehicle(vehicleId))
                {
                    Console.WriteLine($"Vehicle with ID {vehicleId} has been deleted.");
                }
                else
                {
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} is not found");
                }
            }catch (VehicleNotFoundException vnfe)
            {
                Console.WriteLine(vnfe.Message);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateVehicle()
        {
            Console.WriteLine("Update Vehicle:");

            Vehicle updatedVehicle = new Vehicle();

            Console.Write("Enter VehicleID to update: ");
            if (int.TryParse(Console.ReadLine(), out int vehicleID))
            {
                Vehicle existingVehicle = _vehicleRepository.GetVehicleById(vehicleID);

                if (existingVehicle == null)
                {
                    throw new VehicleNotFoundException("\"Vehicle not found. Please enter a valid VehicleID.");
                }

                Console.WriteLine("Current Vehicle Details:");
                Console.WriteLine(existingVehicle);

                Console.WriteLine("Enter updated information (leave blank to keep current value):");

                Console.WriteLine("Registration Number: ");
                string modelInput = Console.ReadLine();
                updatedVehicle.RegistrationNumber = string.IsNullOrWhiteSpace(modelInput) ? existingVehicle.RegistrationNumber : modelInput;

                Console.WriteLine("Availability (true/false): ");
                string availabilityInput = Console.ReadLine();
                 updatedVehicle.Availability= string.IsNullOrWhiteSpace(availabilityInput) ? existingVehicle.Availability : bool.Parse(availabilityInput);

                Console.WriteLine("Daily rate Updation (enter the value): ");
                string rateInput=Console.ReadLine();
                updatedVehicle.DailyRate = string.IsNullOrWhiteSpace(rateInput) ? existingVehicle.DailyRate : decimal.Parse(rateInput);

                if (_vehicleRepository.UpdateVehicle(updatedVehicle))
                {
                    Console.WriteLine("Vehicle updated successfully!");
                }
                else
                {
                    Console.WriteLine("Vehicle not updated");
                }
                
            }
        }
    }
}
