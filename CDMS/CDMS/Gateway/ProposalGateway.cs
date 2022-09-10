using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class ProposalGateway : Gateway
    {
        public int Save(Proposal aProposal)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO Proposal (ProposalNo, CompanyId, BranchId, Remarks, Description, StatusId, CustomerId, CreatedBy, CreatedDate) " +
                        "               VALUES(@ProposalNo, @CompanyId, @BranchId, @remarks, @description, @statusId, @customerId, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("id", aProposal.ProposalId);
                Command.Parameters.AddWithValue("ProposalNo", aProposal.ProposalNo);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToInt32(aProposal.CompanyId));
                Command.Parameters.AddWithValue("BranchId", Convert.ToInt32(aProposal.BranchId));
                Command.Parameters.AddWithValue("remarks", Convert.ToString(aProposal.Remarks));
                Command.Parameters.AddWithValue("description", Convert.ToString(aProposal.Description));
                Command.Parameters.AddWithValue("statusId", Convert.ToInt32(aProposal.StatusId));
                Command.Parameters.AddWithValue("customerId", Convert.ToInt32(aProposal.CustomerId));
                Command.Parameters.AddWithValue("createdBy", aProposal.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aProposal.CreatedDate);
                //Command.Parameters.AddWithValue("updatedBy", aProposal.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aProposal.UpdatedDate);


                Connection.Open();
                rowCount = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
                Connection.Close();

            }
            Connection.Close();
            return rowCount;
        }


        public int Update(Proposal aProposal)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE Proposal SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNumber = @registerNumber, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                //Command.Parameters.AddWithValue("id", aProposal.ProposalId);
                //Command.Parameters.AddWithValue("name", aProposal.Name);
                //Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aProposal.CompanyId));
                //Command.Parameters.AddWithValue("address", Convert.ToString(aProposal.Address));
                //Command.Parameters.AddWithValue("email", Convert.ToString(aProposal.Email));
                //Command.Parameters.AddWithValue("phone", Convert.ToString(aProposal.Phone));
                //Command.Parameters.AddWithValue("fax", Convert.ToString(aProposal.Fax));
                //Command.Parameters.AddWithValue("cell", Convert.ToString(aProposal.Cell));
                //Command.Parameters.AddWithValue("registerNumber", Convert.ToString(aProposal.RegisterNumber));
                //Command.Parameters.AddWithValue("createdBy", aProposal.CreatedBy);
                //Command.Parameters.AddWithValue("createdDate", aProposal.CreatedDate);
                Command.Parameters.AddWithValue("updatedBy", aProposal.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aProposal.UpdatedDate);


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
        public List<Proposal> GetAllProposal()
        {
            List<Proposal> Proposal = new List<Proposal>();

            try
            {
                Query = "SELECT P.Id, P.ProposalNo, P.CompanyId, P.BranchId, P.remarks, P.description, P.statusId, P.customerId, P.CreatedBy, P.CreatedDate, C.CustomerName CustomerName, " +
                        "   S.Description AS StatusDescription, U.NormalizedUserName CreatedByName, P.UpdatedBy, P.UpdatedDate, P.Remarks " +
                        " FROM Proposal P " +
                        " LEFT JOIN Customer C on P.CustomerId = C.Id " +
                        " LEFT JOIN Statuses S on P.StatusId = S.Id " +
                        " LEFT JOIN Users U on P.CreatedBy = U.Id ";

                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    Proposal aProposal = new Proposal()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        ProposalNo = Convert.ToString(Reader["ProposalNo"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        Remarks = Convert.ToString(Reader["Remarks"]),
                        Description = Convert.ToString(Reader["description"]),
                        StatusId = Convert.ToInt32(Reader["statusId"]),
                        StatusDescription = Convert.ToString(Reader["StatusDescription"]),
                        CustomerId = Convert.ToInt32(Reader["CustomerId"]),
                        CustomerName = Convert.ToString(Reader["CustomerName"]),
                        CreatedByName = Convert.ToString(Reader["CreatedByName"]),
                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Proposal.Add(aProposal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Proposal;
        }
    }
}