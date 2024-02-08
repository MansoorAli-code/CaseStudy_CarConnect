using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    public interface IVehicleService
    {
        void GetAvailableVehicles();
        void AddVehicle();
        void UpdateVehicle();
        void RemoveVehicle();
    }
}
