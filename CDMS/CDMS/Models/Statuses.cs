using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDMS.Models
{
    public class Statuses
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StatusFor { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public const string Proposal = "PRP";
        public const string Project = "PRJ";
        public const string Task = "TK";

    }
}
