using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDMS.BLL;
using CDMS.Models;

namespace CDMS.Controllers.Api
{
    //[Authorize]
     
    public class CustomerController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        CustomerManager aCustomerManager = new CustomerManager();

        [HttpGet]
        public ActionResult SaveCustomer()
        {
            Customer aCustomer = new Customer();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Customer = aCustomerManager.GetAllCustomer();
            return View(aCustomer);
        }

        [HttpPost]
        public ActionResult SaveCustomer(Customer aCustomer)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aCustomer.CreatedBy = Convert.ToInt16(Session["Id"]);
            aCustomer.CreatedDate = DateTime.Now;
            aCustomer.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aCustomer.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aCustomerManager.Save(aCustomer);
            return View(aCustomer);
        }


        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer aCustomer = aCustomerManager.GetCustomerById(id);

            return View("Edit", aCustomer);
        }

        [HttpPost]
        public ActionResult Edit(int id, Customer aCustomer)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aCustomer.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aCustomer.UpdatedDate = DateTime.Now;
            ViewBag.Message = aCustomerManager.Update(aCustomer);
            return View(aCustomer);
        }
        //------------------------------------------------
        [HttpGet]
        public JsonResult IsEmailExist(Customer aCustomer)
        {
            List<Customer> Customer = aCustomerManager.GetAllCustomer();
            bool isExist = Customer.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aCustomer.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerById(Customer branch)
        {
            var Customeres = aCustomerManager.GetAllCustomer();
            var CustomerList = Customeres.Where(t => t.CustomerId == branch.CustomerId).ToList();
            return Json(CustomerList);
        }

        [HttpGet]
        public ActionResult ViewCustomer()
        {
            List<Customer> Customer = aCustomerManager.GetAllCustomer();
            ViewBag.Customer = aCustomerManager.GetAllCustomer();
            return View(Customer);
        }
    }
}