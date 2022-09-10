using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CDMS.Models
{
    public class ProposalFeedback
    {
        public Int64 Id { get; set; }

        public Int64 ProposalId { get; set; }

        [Display(Name = "Propsal Number")]
        public string ProposalNo { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        public string Description { get; set; }

        public int? AssignedTo { get; set; }
        public string AssignedToName { get; set; }

        public string Status { get; set; }

        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? BranchId { get; set; }

        public int? CompanyId { get; set; }
        public List<UserProfile> UserProfile { get; set; } = new List<UserProfile>();
        public List<Proposal> Proposal { get; set; } = new List<Proposal>();

        //public enum RC
        //{
        //    Default,  //0
        //    Lessor,   //1
        //    Lessee     //2
        //}
    }
}
