using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDMS.Models;
using CDMS.Services;
using System;
using System.Web.Mvc;

namespace CDMS.Controllers
{
    //[Authorize]
    //[Produces("application/json")]
    //[Route("api/Project")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        //public ProjectController(ApplicationDbContext context, INumberSequence numberSequence, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        //{

        public ProjectController(ApplicationDbContext context, INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        // GET: api/Project
        //[HttpGet]
        //public async Task<IActionResult> GetProject()
        //{
        //    List<Project> Items = await _context.Project.ToListAsync();
        //    int Count = Items.Count();
        //    return Ok(new { Items, Count });
        //}

        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    Project result = await _context.Project
        //            .Where(x => x.Id.Equals(id))
        //            .Include(x => x.Id)
        //            .FirstOrDefaultAsync();

        //    return Ok(result);
        //}

        //private void UpdateProject(Guid ProjectId)
        //{
        //    try
        //    {
        //        var user = _userManager.GetUserAsync(User);
        //        Project Project = new Project();
        //        Project = _context.Project
        //            .Where(x => x.Id.Equals(ProjectId))
        //            .FirstOrDefault();
        //        _context.Update(Project);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost("[action]")]
        //public IActionResult Insert([FromBody]CrudViewModel<Project> payload)
        //{
        //    Project Project = payload.value;
        //    var user = _userManager.GetUserAsync(User);
        //    Project.ProjectNo = _numberSequence.GetNumberSequence("PRJ");
        //    Project.CreatedBy = _userManager.GetUserId(User);
        //    Project.Customer = payload.value.Customer;
        //    Project.StartDate = payload.value.StartDate;
        //    Project.ProjectCost = payload.value.ProjectCost;
        //    Project.EndtDate = payload.value.EndtDate;
        //    Project.StatusId = payload.value.StatusId;
        //    Project.SalesOrderNo= payload.value.SalesOrderNo;
            
        //    _context.Project.Add(Project);
        //    _context.SaveChanges();
        //    this.UpdateProject(Project.Id);
        //    return Ok(Project);
        //}

       

        //[HttpPost("[action]")]
        //public IActionResult Update([FromBody]CrudViewModel<Project> payload)
        //{
        //    Project Project = payload.value;
        //    _context.Project.Update(Project);
        //    _context.SaveChanges();
        //    return Ok(Project);
        //}

        //[HttpPost("[action]")]
        //public IActionResult Remove([FromBody]CrudViewModel<Project> payload)
        //{
        //    Project Project = _context.Project
        //            .Where(x => x.Id == (Guid)payload.key)
        //            .FirstOrDefault();
        //    _context.Project.Remove(Project);
        //    _context.SaveChanges();
        //    return Ok(Project);

        //}
    }
}