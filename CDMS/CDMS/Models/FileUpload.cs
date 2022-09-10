using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDMS.Models
{
    public class FileUpload
    {
        [Key]
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ControllerName { get; set; }
        public int ControllerId { get; set; }
        public IEnumerable<FileUpload> FileList { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int? BranchId { get; set; }

        public int? CompanyId { get; set; }
    }
}
