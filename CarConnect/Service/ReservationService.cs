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
    public class ReservationService : IReservationService
    {
        readonly IReservationRepository reservationRepository;
        readonly IVehicleRepository vehicleRepository;
        public ReservationService()
        {
            reservationRepository = new ReservationRepository();
        }

        public void CalculateTotalCost()
        {
            Console.WriteLine("Enter the reservation id");
            int id = int.Parse(Console.ReadLine());
            Reservation reservation = reservationRepository.GetReservationById(id);
            decimal totalCost = reservationRepository.CalculateTotalCost(reservation.StartDate, reservation.EndDate, reservation.VehicleID);
            Console.WriteLine($"The Total Cost of Reservation id ({reservation.ReservationID} : {totalCost})"); 
        }

        public void CancelReservation()
        {
            Console.WriteLine("Enter Id to delete");
            int id = int.Parse(Console.ReadLine());
            
            if (reservationRepository.CancelReservation(id))
            {
                Console.WriteLine($"The reservation {id} is succesfully cancelled");
            }else { Console.WriteLine("The Resrvation cancellation is failed"); }
        }

        public void CreateReservation(int id)
        {
            try
            {
                Console.WriteLine("To Create reservation");
                Console.WriteLine("Enter the ReservationID: ");
                int rid = int.Parse(Console.ReadLine()) ;
                Console.WriteLine("Enter the VehicleID: ");
                int vid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the StartDate: ");
                DateTime sd = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the EndDate: ");
                DateTime ed = DateTime.Parse(Console.ReadLine());
                decimal tc = reservationRepository.CalculateTotalCost(sd, ed, vid);
                string sts = "confirmed";
                Reservation reservation = new Reservation
                {
                    ReservationID = rid,
                    CustomerID = id,
                    VehicleID = vid,
                    StartDate = sd,
                    EndDate = ed,
                    TotalCost = tc,
                    Status = sts
                };
                reservationRepository.CreateReservation(reservation);   
                Console.WriteLine($"The total cost of the ride : {tc}Rs!!");
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void GetAllReservations()
        {
            try
            {
                List<Reservation> reservations = reservationRepository.GetAllReservations();
                if (reservations != null)
                {
                    foreach (Reservation reservation in reservations)
                    {
                        Console.WriteLine(reservation);
                    }
                }
                else
                {
                    throw new ReservationException("No reservations found");
                }
                
            }catch(ReservationException re)
            {
                Console.WriteLine(re.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        

        public void GetReservationById(int id)
        {
            try
            {
                List<Reservation> reservations = reservationRepository.GetReservationsByCustomerId(id);
                if (reservations.Count > 0)
                {
                    foreach (Reservation reservation in reservations)
                    {
                        Console.WriteLine(reservation);
                    }
                }
                else
                {
                    throw new ReservationException($"No reservations found with the id {id}");
                }
            }catch(ReservationException re)
            {
                Console.WriteLine(re.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateReservation(Reservation data)
        {
            
        }

        
    }
}
