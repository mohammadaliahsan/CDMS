using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDMS.Models
{
    public class Tasks
    {
        public Int64 Id { get; set; }

        [Display(Name = "Task Number")]
        public string TaskNo { get; set; }

        public Guid ProjectId { get; set; }

        [Display(Name = "Project Number")]
        public string ProjectNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndtDate { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public List<Project> project { get; set; } = new List<Project>();
        public int? AssignedBy { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }


    }
}
