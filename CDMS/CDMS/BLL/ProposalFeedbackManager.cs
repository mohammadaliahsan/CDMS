using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class ProposalFeedbackManager
    {
        ProposalFeedbackGateway aProposalFeedbackGateway = new ProposalFeedbackGateway();
        string successMessage = string.Empty;

        public string Save(ProposalFeedback aProposalFeedback)
        {
            try
            {
                if (aProposalFeedbackGateway.Save(aProposalFeedback) > 0)
                {
                    successMessage = "ProposalFeedback Save Successfully!!";
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

        public string Update(ProposalFeedback aProposalFeedback)
        {
            try
            {
                if (aProposalFeedbackGateway.Update(aProposalFeedback) > 0)
                {
                    successMessage = "ProposalFeedback Save Successfully!!";
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

        public List<ProposalFeedback> GetAllProposalFeedback()
        {
            return aProposalFeedbackGateway.GetAllProposalFeedback();
        }

        public ProposalFeedback GetProposalFeedbackById(int ProposalFeedbackId)
        {
            var branches = GetAllProposalFeedback();
            ProposalFeedback branch = branches.FirstOrDefault(t => t.Id == ProposalFeedbackId);
            return branch;
        }
    }
}