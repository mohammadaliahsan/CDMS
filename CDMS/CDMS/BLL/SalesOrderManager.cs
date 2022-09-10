using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class SalesOrderManager
    {
        SalesOrderGateway aSalesOrderGateway = new SalesOrderGateway();
        string successMessage = string.Empty;

        public string Save(SalesOrder aSalesOrder)
        {
            try
            {
                if (aSalesOrderGateway.Save(aSalesOrder) > 0)
                {
                    successMessage = "SalesOrder Save Successfully!!";
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

        public string Update(SalesOrder aSalesOrder)
        {
            try
            {
                if (aSalesOrderGateway.Update(aSalesOrder) > 0)
                {
                    successMessage = "SalesOrder Save Successfully!!";
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

        public List<SalesOrder> GetAllSalesOrder()
        {
            return aSalesOrderGateway.GetAllSalesOrder();
        }

        public SalesOrder GetSalesOrderById(int SalesOrderId)
        {
            var branches = GetAllSalesOrder();
            SalesOrder branch = branches.FirstOrDefault(t => t.SalesOrderId == SalesOrderId);
            return branch;
        }
    }
}