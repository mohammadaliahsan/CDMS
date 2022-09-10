using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class CustomerGateway : Gateway
    {
        public int Save(Customer aCustomer)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Customer (CustomerName, CompanyId, BranchId, Address, Email, Phone, State, Zipcode, CreatedBy, CreatedDate) " +
                        "VALUES(@customername, @Companyid, @BranchId, @address, @email, @phone, @state, @zipcode, @createdBy, @createdDate)";

                Command = new MySqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("id", aCustomer.CustomerId);
                Command.Parameters.AddWithValue("customername", aCustomer.CustomerName);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToInt64(aCustomer.CompanyId));
                Command.Parameters.AddWithValue("BranchId", Convert.ToInt64(aCustomer.BranchId));
                Command.Parameters.AddWithValue("address", Convert.ToString(aCustomer.Address));
                Command.Parameters.AddWithValue("email", Convert.ToString(aCustomer.Email));
                Command.Parameters.AddWithValue("phone", Convert.ToString(aCustomer.Phone));
                Command.Parameters.AddWithValue("state", Convert.ToString(aCustomer.State));
                Command.Parameters.AddWithValue("zipcode", Convert.ToString(aCustomer.ZipCode));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aCustomer.RegisterNumber));
                Command.Parameters.AddWithValue("createdBy", aCustomer.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aCustomer.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aCustomer.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aCustomer.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                Connection.Close();
                throw ex;
            }
            Connection.Close();
            return rowCount;
        }


        public int Update(Customer aCustomer)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE Customer SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNumber = @registerNumber, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("id", aCustomer.CustomerId);
                //Command.Parameters.AddWithValue("name", aCustomer.Name);
                //Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aCustomer.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aCustomer.Address));
                //Command.Parameters.AddWithValue("email", Convert.ToString(aCustomer.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aCustomer.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aCustomer.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aCustomer.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aCustomer.RegisterNumber));
                ////Command.Parameters.AddWithValue("createdBy", aCustomer.CreatedBy);
                ////Command.Parameters.AddWithValue("createdDate", aCustomer.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aCustomer.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aCustomer.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            return rowCount;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> Customer = new List<Customer>();

            try
            {
                Query = "SELECT * FROM Customer";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Customer aCustomer = new Customer()
                    {
                        CustomerId = Convert.ToInt32(Reader["Id"]),
                        CustomerName = Convert.ToString(Reader["CustomerName"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        Address = Convert.ToString(Reader["Address"]),
                        Email = Convert.ToString(Reader["Email"]),
                        Phone = Convert.ToString(Reader["Phone"]),
                        State = Convert.ToString(Reader["State"]),
                        ZipCode = Convert.ToString(Reader["ZipCode"]),
                       // RegisterNumber = Convert.ToString(Reader["RegisterNumber"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Customer.Add(aCustomer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Customer;
        }
    }
}