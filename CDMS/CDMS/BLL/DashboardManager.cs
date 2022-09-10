using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class DashboardManager
    {
        DashboardGateway aDashboardGateway = new DashboardGateway();
        //PropertyGateway aPropertyGateway = new PropertyGateway();
        //LesseeLessorGateway aLesseeLessorGateway = new LesseeLessorGateway();


        public int GetTotalFlat()
        {
            //return aPropertyGateway.GetAllProperty().Where(t=> t.PropertyType == Convert.ToInt16(Property.PT.Flat)).ToList().Count();
            return 1;
        }

        public int GetTotalBuildingVellasShops()
        {
            //return aPropertyGateway.GetAllProperty().Where(t => t.PropertyType != Convert.ToInt16(Property.PT.Flat)).ToList().Count();
            return 2;
        }

        public int GetTotalPendingChques()
        {
            //return aDashboardGateway.GetTotalDepartment();
            return 5;
        }

        public int GetTotalRenewalProperty()
        {
            return 6;//aDashboardGateway.GetTotalRoom();
        }

        //public List<ChartVM> GetCount()
        //{
        //    return aDashboardGateway.GetCount();
        //}

        //public List<Company> GetCompany()
        //{
        //    return aDashboardGateway.GetCompany();
        //}


        //public List<Branch> GetBranch()
        //{
        //    return aDashboardGateway.GetBranch();
        //}
    }
}