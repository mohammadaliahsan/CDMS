using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class UsersGateway : Gateway
    {
        public int Save(Users users)
        {
            Query = "INSERT INTO Users (Name, UserName, Password, CompanyId, BranchId) VALUES (@n, @un, @pw, @CompanyId, @BranchId)";
            Command = new MySqlCommand(Query, Connection); 
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("n", users.Name);
            Command.Parameters.AddWithValue("un", users.UserName);
            Command.Parameters.AddWithValue("pw", users.Password);
            Command.Parameters.AddWithValue("CompanyId", users.CompanyId);
            Command.Parameters.AddWithValue("BranchId", users.BranchId);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }
        public int SaveChangePassword(UsersChangePassowrd users)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Users (Name,UserName, Password) VALUES (@n,@un, @pw)";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("n", users.Name);
                Command.Parameters.AddWithValue("un", users.UserName);
                Command.Parameters.AddWithValue("pw", users.Password);
                Connection.Open();
                rowCount = Command.ExecuteNonQuery();
                Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowCount;
        }

        public List<Users> GetUser()
        {
            List<Users> usersList = new List<Users>();
            try
            {
                Query = "SELECT * FROM Users";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Users aUsers = new Users();

                    aUsers.Id = Convert.ToInt32(Reader["Id"]);
                    aUsers.Name = Convert.ToString(Reader["UserName"]);
                    aUsers.UserName = Convert.ToString(Reader["UserName"]);
                    aUsers.Password = Convert.ToString(Reader["PasswordHash"]);
                    aUsers.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                    aUsers.BranchId = Convert.ToInt32(Reader["BranchId"]);
                    usersList.Add(aUsers);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return usersList;
        }
    }
}