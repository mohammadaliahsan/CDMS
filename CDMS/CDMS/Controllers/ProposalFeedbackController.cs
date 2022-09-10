using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDMS.Models;
using CDMS.Services;
using System;
using System.Web.Mvc;
using CDMS.BLL;

namespace CDMS.Controllers
{
    //[Authorize]
    //[Produces("application/json")]
    //[Route("api/ProposalFeedback")]
    public class ProposalFeedbackController : Controller
    {
        //DepartmentManager aDepartmentManager = new DepartmentManager();
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        ProposalFeedbackManager aProposalFeedbackManager = new ProposalFeedbackManager();
        ProposalManager aProposalManager = new ProposalManager();
        StatusesManager aStatusesManager = new StatusesManager();
        Statuses status = new Statuses();
        List<Proposal> proposalList;

        [HttpGet]
        public ActionResult SaveProposalFeedback()
        {
            ProposalFeedback aProposalFeedback = new ProposalFeedback();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            ViewBag.ProposalFeedback = aProposalFeedbackManager.GetAllProposalFeedback();

            status = aStatusesManager.GetStatusByStatusForDescription(Statuses.Proposal, "Created");
            ViewBag.ProposalNo = aProposalManager.GetAllProposalByStatus(status.Id);

            return View(aProposalFeedback);
        }

        [HttpPost]
        public ActionResult SaveProposalFeedback(ProposalFeedback aProposalFeedback)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();
            status = aStatusesManager.GetStatusByStatusForDescription(Statuses.Proposal, "Created");


            proposalList = new List<Proposal>();
            ViewBag.ProposalNo = proposalList = aProposalManager.GetAllProposalByStatus(status.Id);

            if (proposalList.Count > 0)
            {
                aProposalFeedback.ProposalId = proposalList.Where(t => t.ProposalNo == aProposalFeedback.ProposalNo).FirstOrDefault().Id;
                aProposalFeedback.AssignedTo = proposalList.Where(t => t.ProposalNo == aProposalFeedback.ProposalNo).FirstOrDefault().CreatedBy;
            }

            aProposalFeedback.CreatedBy = Convert.ToInt16(Session["Id"]);
            aProposalFeedback.CreatedDate = DateTime.Now;
            aProposalFeedback.CompanyId = Convert.ToInt16(Session["CompanyId"]);
            aProposalFeedback.BranchId = Convert.ToInt16(Session["BranchId"]);
            ViewBag.Message = aProposalFeedbackManager.Save(aProposalFeedback);
            return View(aProposalFeedback);
        }


        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProposalFeedback aProposalFeedback = aProposalFeedbackManager.GetProposalFeedbackById(id);

            return View("Edit", aProposalFeedback);
        }

        [HttpPost]
        public ActionResult Edit(int id, ProposalFeedback aProposalFeedback)
        {
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aProposalFeedback.UpdatedBy = Convert.ToInt16(Session["Id"]);
            aProposalFeedback.UpdatedDate = DateTime.Now;
            ViewBag.Message = aProposalFeedbackManager.Update(aProposalFeedback);
            return View(aProposalFeedback);
        }
        //------------------------------------------------

        //[HttpGet]
        //public JsonResult IsEmailExist(ProposalFeedback aProposalFeedback)
        //{
        //    List<ProposalFeedback> ProposalFeedback = aProposalFeedbackManager.GetAllProposalFeedback();
        //    bool isExist = ProposalFeedback.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aProposalFeedback.Email.ToLower())) != null;
        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetProposalFeedbackById(ProposalFeedback proposalFeedback)
        {
            var ProposalFeedbackes = aProposalFeedbackManager.GetAllProposalFeedback();
            var ProposalFeedbackList = ProposalFeedbackes.Where(t => t.Id == proposalFeedback.Id).ToList();
            return Json(ProposalFeedbackList);
        }

        [HttpGet]
        public ActionResult ViewProposalFeedback()
        {
            List<ProposalFeedback> ProposalFeedback = aProposalFeedbackManager.GetAllProposalFeedback();
            ViewBag.ProposalFeedback = aProposalFeedbackManager.GetAllProposalFeedback();
            return View(ProposalFeedback);
        }
    }
}