using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDMS.Models
{
    public class Project
    {
        public Int64 Id { get; set; }

        [Display(Name = "Project Number")]
        public string ProjectNo { get; set; }
        public string SalesOrderNo { get; set; }
        [Display(Name = "Customer Name")]
        public string Customer { get; set; }
        [Display(Name = "Project Cost")]
        public decimal ProjectCost { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public List<SalesOrder> SalesOrder { get; set; } = new List<SalesOrder>();
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }

    }
}
