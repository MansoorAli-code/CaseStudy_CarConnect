using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    internal interface ICustomerRepository
    {
        //create
        bool RegisterCustomer(Customer customer);

        //read
        Customer GetCustomerByID(int id);
        Customer GetCustomerByUsername(string username);
        List<Customer> GetAllCustomers();
        
        //update
        bool UpdateCustomerDetailsByID(Customer customerData,int id);

        //delete
        bool DeleteCustomerDetailsByID(int id);

        bool AuthenticateCustomer(string username, string password);

        
    }
}
