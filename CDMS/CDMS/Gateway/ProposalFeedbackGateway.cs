using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using CDMS.Models;

namespace CDMS.Gateway
{
    public class ProposalFeedbackGateway : Gateway
    {
        public int Save(ProposalFeedback aProposalFeedback)
        {
            int rowCount = 0;
            try
            {
                Query = "INSERT INTO ProposalFeedback (CompanyId, BranchId, ProposalId, ProposalNo, Description, Remarks, AssignedTo, CreatedBy, CreatedDate) " +
                        "VALUES(@companyid, @branchid, @proposalid, @proposalno, @description, @remarks, @assignedto, @createdBy, @createdDate)";
                Command = new MySqlCommand(Query, Connection);
                //Command.Parameters.AddWithValue("id", aProposalFeedback.Id);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aProposalFeedback.CompanyId));
                Command.Parameters.AddWithValue("BranchId", Convert.ToString(aProposalFeedback.BranchId));
                Command.Parameters.AddWithValue("ProposalId", Convert.ToString(aProposalFeedback.ProposalId));
                Command.Parameters.AddWithValue("ProposalNo", Convert.ToString(aProposalFeedback.ProposalNo));
                Command.Parameters.AddWithValue("Description", Convert.ToString(aProposalFeedback.Description));
                Command.Parameters.AddWithValue("Remarks", Convert.ToString(aProposalFeedback.Remarks));
                Command.Parameters.AddWithValue("AssignedTo", aProposalFeedback.AssignedTo);

                Command.Parameters.AddWithValue("createdBy", aProposalFeedback.CreatedBy);
                Command.Parameters.AddWithValue("createdDate", aProposalFeedback.CreatedDate);

                //Command.Parameters.AddWithValue("updatedBy", aProposalFeedback.UpdatedBy);
                //Command.Parameters.AddWithValue("updatedDate", aProposalFeedback.UpdatedDate);


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


        public int Update(ProposalFeedback aProposalFeedback)
        {
            int rowCount = 0;
            try
            {
                Query = "UPDATE ProposalFeedback SET Name = @name, CompanyId = @companyid, Address = @address, Email = @email, Phone = @phone, " +
                                                            "Fax = @fax, Cell = @cell, RegisterNo = @registerNo, UpdatedBy = @updatedBy, " +
                                                            " UpdatedDate = @updatedDate WHERE  Id = @id ";

                Command = new MySqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("id", aProposalFeedback.Id);
                //Command.Parameters.AddWithValue("name", aProposalFeedback.Name);
                Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aProposalFeedback.CompanyId));
                //Command.Parameters.AddWithValue("createdBy", aProposalFeedback.CreatedBy);
                //Command.Parameters.AddWithValue("createdDate", aProposalFeedback.CreatedDate);
                Command.Parameters.AddWithValue("updatedBy", aProposalFeedback.UpdatedBy);
                Command.Parameters.AddWithValue("updatedDate", aProposalFeedback.UpdatedDate);


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
        public List<ProposalFeedback> GetAllProposalFeedback()
        {
            List<ProposalFeedback> ProposalFeedback = new List<ProposalFeedback>();

            try
            {
                Query = "SELECT PF.Id, PF.CreatedBy, CB.NormalizedUserName AS CreatedByName, PF.CreatedDate, PF.ProposalNo, PF.ProposalId, PF.Remarks, PF.Description, " +
                    "   PF.AssignedTo, ATo.NormalizedUserName AS AssignedToName, PF.UpdatedBy,PF.UpdatedDate, PF.CompanyId, PF.BranchId " +
                    "   FROM proposalfeedback PF " +
                    "   INNER JOIN proposal P ON PF.ProposalId = P.Id " +
                    "   LEFT JOIN users CB ON PF.CreatedBy = CB.Id " +
                    "   LEFT JOIN users ATo ON PF.AssignedTo = Ato.Id ";

                Command = new MySqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ProposalFeedback aProposalFeedback = new ProposalFeedback()
                    {
                        Id = Convert.ToInt64(Reader["Id"]),
                        //Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        ProposalId = Convert.ToInt32(Reader["ProposalId"]),
                        ProposalNo = Convert.ToString(Reader["ProposalNo"]),
                        Description = Convert.ToString(Reader["Description"]),
                        Remarks = Convert.ToString(Reader["Remarks"]),
                        AssignedTo = Convert.ToInt32(Reader["AssignedTo"]),


                        CreatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedBy"])) ? 0 : Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["CreatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    ProposalFeedback.Add(aProposalFeedback);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return ProposalFeedback;
        }
    }
}