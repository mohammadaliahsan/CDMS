using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class CustomerManager
    {
        CustomerGateway aCustomerGateway = new CustomerGateway();
        string successMessage = string.Empty;

        public string Save(Customer aCustomer)
        {
            try
            {
                if (aCustomerGateway.Save(aCustomer) > 0)
                {
                    successMessage = "Customer Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message;
            }
            return successMessage;
        }

        public string Update(Customer aCustomer)
        {
            try
            {
                if (aCustomerGateway.Update(aCustomer) > 0)
                {
                    successMessage = "Customer Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message;
            }
            return successMessage;
        }

        public List<Customer> GetAllCustomer()
        {
            return aCustomerGateway.GetAllCustomer();
        }

        public Customer GetCustomerById(int CustomerId)
        {
            var branches = GetAllCustomer();
            Customer branch = branches.FirstOrDefault(t => t.CustomerId == CustomerId);
            return branch;
        }
    }
}