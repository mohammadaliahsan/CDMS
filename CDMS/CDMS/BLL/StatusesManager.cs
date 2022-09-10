using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class StatusesManager
    {
        StatusesGateway aStatusesGateway = new StatusesGateway();
        string successMessage = string.Empty;

        public List<Statuses> GetAllStatuses()
        {
            StatusesGateway aStatusesGateway = new StatusesGateway();
            return aStatusesGateway.GetAllStauses();
        }

        public List<Statuses> GetAllStatusesByStatusFor(string statusFor)
        {
            StatusesGateway aStatusesGateway = new StatusesGateway();
            return aStatusesGateway.GetAllStauses().Where(t => t.StatusFor == statusFor).ToList(); ;
        }

        public Statuses GetStatusByStatusForDescription(string statusFor, string description)
        {
            StatusesGateway aStatusesGateway = new StatusesGateway();
            return aStatusesGateway.GetAllStauses().FirstOrDefault(t => t.StatusFor == statusFor && t.Description == description) ;
        }

    }
}