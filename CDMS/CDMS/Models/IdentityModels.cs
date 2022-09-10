using Microsoft.AspNet.Identity.EntityFramework;

namespace CDMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //public System.Data.Entity.DbSet<CDMS.Models.Department> Departments { get; set; }

        //public System.Data.Entity.DbSet<CDMS.Models.Teacher> Teachers { get; set; }

        //public System.Data.Entity.DbSet<CDMS.Models.Driver> Drivers { get; set; }

        public System.Data.Entity.DbSet<CDMS.Models.Users> Admins { get; set; }
        public System.Data.Entity.DbSet<CDMS.Models.Company> Company { get; set; }

        public System.Data.Entity.DbSet<CDMS.Models.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<CDMS.Models.Project> Properties { get; set; }

        public System.Data.Entity.DbSet<CDMS.Models.NumberSequence> NumberSequence { get; set; }
    }
}