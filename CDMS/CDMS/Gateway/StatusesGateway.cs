using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class StatusesGateway : Gateway
    {
        public List<Statuses> GetAllStauses()
        {
            List<Statuses> Statuses = new List<Statuses>();

            try
            {
                Query = "SELECT * FROM statuses";
                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Statuses aStatuses = new Statuses()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        StatusFor = Convert.ToString(Reader["StatusFor"]),
                        Value = Convert.ToInt32(Reader["Value"]),
                        Description = Convert.ToString(Reader["Description"])
                    };
                    Statuses.Add(aStatuses);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Statuses;
        }
    }
}