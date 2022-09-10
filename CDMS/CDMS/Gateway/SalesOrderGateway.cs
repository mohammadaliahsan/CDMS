using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class SalesOrderGateway : Gateway
    {
        public int Save(SalesOrder aSalesOrder)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO SalesOrder (Name, CompanyId, Address, Email, Phone, Fax, Cell, RegisterNumber, CreatedBy, CreatedDate) " +
                        "VALUES(@name, @companyid, @address, @email, @phone, @fax, @cell, @registerNumber, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("id", aSalesOrder.SalesOrderId);
                //Command.Parameters.AddWithValue("name", aSalesOrder.Name);
                //Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aSalesOrder.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aSalesOrder.Address));
                //Command.Parameters.AddWithValue("email", Convert.ToString(aSalesOrder.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aSalesOrder.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aSalesOrder.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aSalesOrder.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aSalesOrder.RegisterNumber));
                Command.Parameters.AddWithValue("createdBy", aSalesOrder.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aSalesOrder.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aSalesOrder.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aSalesOrder.UpdatedDate);


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


        public int Update(SalesOrder aSalesOrder)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE SalesOrder SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNumber = @registerNumber, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("id", aSalesOrder.SalesOrderId);
                //Command.Parameters.AddWithValue("name", aSalesOrder.Name);
                //Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aSalesOrder.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aSalesOrder.Address));
                //Command.Parameters.AddWithValue("email", Convert.ToString(aSalesOrder.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aSalesOrder.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aSalesOrder.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aSalesOrder.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aSalesOrder.RegisterNumber));
                //Command.Parameters.AddWithValue("createdBy", aSalesOrder.CreatedBy);
                //Command.Parameters.AddWithValue("createdDate", aSalesOrder.CreatedDate);
                Command.Parameters.AddWithValue("updatedBy", aSalesOrder.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aSalesOrder.UpdatedDate);


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
        public List<SalesOrder> GetAllSalesOrder()
        {
            List<SalesOrder> SalesOrder = new List<SalesOrder>();

            try
            {
                Query = "SELECT * FROM SalesOrder";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    SalesOrder aSalesOrder = new SalesOrder()
                    {
                        SalesOrderId = Convert.ToInt32(Reader["Id"]),
                        //Name = Convert.ToString(Reader["Name"]),
                        //CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        //Address = Convert.ToString(Reader["Address"]),
                        //Email = Convert.ToString(Reader["Email"]),
                        //Phone = Convert.ToString(Reader["Phone"]),
                        //Fax = Convert.ToString(Reader["Fax"]),
                        //Cell = Convert.ToString(Reader["Cell"]),
                        //RegisterNumber = Convert.ToString(Reader["RegisterNumber"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    SalesOrder.Add(aSalesOrder);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return SalesOrder;
        }
    }
}