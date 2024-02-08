using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    public interface IReservationService
    {
        void GetReservationById(int id);
        void GetAllReservations();
        void CreateReservation(int id);
        void UpdateReservation(Reservation data);
        void CancelReservation();
        void CalculateTotalCost();
    }
}
