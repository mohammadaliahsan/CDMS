using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CDMS.Models
{
    public class Proposal
    {
        public int Id { get; set; }

        [Display(Name = "Propsal Number")]
        public string ProposalNo { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

      
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string StatusDescription { get; set; }
        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        //public List<UserProfile> UserProfile { get; set; } = new List<UserProfile>();
        //public List<Statuses> Statuses { get; set; } = new List<Statuses>();

        //public List<Customer> Customer { get; set; } = new List<Customer>();
        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int? BranchId { get; set; }

        public int? CompanyId { get; set; }
    }
}
