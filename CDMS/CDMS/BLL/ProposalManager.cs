using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class ProposalManager
    {
        ProposalGateway aProposalGateway = new ProposalGateway();
        string successMessage = string.Empty;

        public string Save(Proposal aProposal)
        {
            try
            {
                if (aProposalGateway.Save(aProposal) > 0)
                {
                    successMessage = "Proposal Save Successfully!!";
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

        public string Update(Proposal aProposal)
        {
            try
            {
                if (aProposalGateway.Update(aProposal) > 0)
                {
                    successMessage = "Proposal Save Successfully!!";
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

        public List<Proposal> GetAllProposal()
        {
            return aProposalGateway.GetAllProposal();
        }

        public List<Proposal> GetAllProposalByStatus(int statusId)
        {
            return aProposalGateway.GetAllProposal().Where(t => t.StatusId == statusId).ToList();
                                                           
        }


        public Proposal GetProposalById(int ProposalId)
        {
            var branches = GetAllProposal();
            Proposal branch = branches.FirstOrDefault(t => t.Id == ProposalId);
            return branch;
        }
    }
}