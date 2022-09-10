using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDMS.Models;
using CDMS.Services;
using System.Web.Mvc;
using System;
using CDMS.BLL;

namespace CDMS.Controllers.Api
{
    //[Authorize]
    //[Produces("application/json")]
    //[Route("api/Proposal")]
    public class ProposalController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        ProposalManager aProposalManager = new ProposalManager();
        CustomerManager aCustomerManager = new CustomerManager();
        StatusesManager aStatusesManager = new StatusesManager();
        NumberSequenceManager aNumberSequenceManager = new NumberSequenceManager();

        [HttpGet]
        public ActionResult SaveProposal()
        {
            Proposal aProposal = new Proposal();
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Customer = aCustomerManager.GetAllCustomer();
            ViewBag.Proposal = aProposalManager.GetAllProposal();
            ViewBag.Statuses = aStatusesManager.GetAllStatusesByStatusFor(Statuses.Proposal);
            return View(aProposal);
        }

        [HttpPost]
        public ActionResult SaveProposal(Proposal aProposal)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Customer = aCustomerManager.GetAllCustomer();
            ViewBag.Statuses = aStatusesManager.GetAllStatusesByStatusFor(Statuses.Proposal);
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProposal.ProposalNo = aNumberSequenceManager.GetNumberSequence("PRP");
            aProposal.CreatedBy = Convert.ToInt16(Session["Id"]);
            aProposal.CreatedDate = DateTime.Now;
            aProposal.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProposal.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aProposalManager.Save(aProposal);
            return View(aProposal);
        }


        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Proposal aProposal = aProposalManager.GetProposalById(id);

            return View("Edit", aProposal);
        }

        [HttpPost]
        public ActionResult Edit(int id, Proposal aProposal)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProposal.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aProposal.UpdatedDate = DateTime.Now;
            ViewBag.Message = aProposalManager.Update(aProposal);
            return View(aProposal);
        }
        //------------------------------------------------
        //[HttpGet]
        //public JsonResult IsEmailExist(Proposal aProposal)
        //{
        //    List<Proposal> Proposal = aProposalManager.GetAllProposal();
        //    bool isExist = Proposal.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aProposal.Email.ToLower())) != null;
        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetProposalById(Proposal proposal)
        {
            var Proposales = aProposalManager.GetAllProposal();
            var ProposalList = Proposales.Where(t => t.Id == proposal.Id).ToList();
            return Json(ProposalList);
        }

        [HttpGet]
        public ActionResult ViewProposal()
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Customer = aCustomerManager.GetAllCustomer();
            ViewBag.Statuses = aStatusesManager.GetAllStatusesByStatusFor(Statuses.Proposal);

            List<Proposal> proposal = aProposalManager.GetAllProposal();
            ViewBag.Proposal = aProposalManager.GetAllProposal();
            return View(proposal);
        }
    }
}