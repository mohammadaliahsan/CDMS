using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class ProjectGateway : Gateway
    {
        public int Save(Project aProject)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Project (Name, CompanyId, Address, Email, Phone, Fax, Cell, RegisterNumber, CreatedBy, CreatedDate) " +
                        "VALUES(@name, @companyid, @address, @email, @phone, @fax, @cell, @registerNumber, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("id", aProject.ProjectId);
                //Command.Parameters.AddWithValue("name", aProject.Name);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aProject.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aProject.Address));
                //Command.Parameters.AddWithValue("email", Convert.ToString(aProject.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aProject.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aProject.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aProject.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aProject.RegisterNumber));
                Command.Parameters.AddWithValue("createdBy", aProject.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aProject.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aProject.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aProject.UpdatedDate);


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


        public int Update(Project aProject)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE Project SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNumber = @registerNumber, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("id", aProject.Id);
                //Command.Parameters.AddWithValue("name", aProject.Name);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aProject.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aProject.Address));
                ///Command.Parameters.AddWithValue("email", Convert.ToString(aProject.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aProject.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aProject.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aProject.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aProject.RegisterNumber));
                //Command.Parameters.AddWithValue("createdBy", aProject.CreatedBy);
                //Command.Parameters.AddWithValue("createdDate", aProject.CreatedDate);
                Command.Parameters.AddWithValue("updatedBy", aProject.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aProject.UpdatedDate);


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
        public List<Project> GetAllProject()
        {
            List<Project> Project = new List<Project>();

            try
            {
                Query = "SELECT * FROM Project";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Project aProject = new Project()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        //Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
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
                    Project.Add(aProject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Project;
        }
    }
}