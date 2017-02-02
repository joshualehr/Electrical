using Electrical.Data;
using Electrical.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Electrical.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Project/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.AsNoTracking()
                .OrderBy(p => p.Designation)
                .Select(p => new IndexItemViewModel { ProjectId = p.ProjectId, Designation = p.Designation })
                .ToListAsync();
            
            return View(new IndexViewModel { Projects = projects });
        }
    }
}