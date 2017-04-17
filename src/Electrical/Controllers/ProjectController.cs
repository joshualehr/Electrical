using Electrical.Data;
using Electrical.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Electrical.Controllers
{
    [Authorize(Roles = "isEmployee")]
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

            if (projects.Count > 0)
            {
                if (User.IsInRole("canManageProjects"))
                {
                    return View(new IndexViewModel { Projects = projects });
                }
                else
                {
                    return RedirectToAction(nameof(ProjectController.Create));
                }
            }
            return RedirectToAction(nameof(HomeController.Index));
        }

        // GET: /Project/Create
        [Authorize(Roles = "canManageProjects")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var role = await _context.Roles.SingleAsync(r => r.Name == "canManageProjects");
            return View(new CreateViewModel
            {
                Users = _context.Users.AsNoTracking()
                .Include(u => u.Roles)
                .Where(u => u.Roles.Any(r => r.RoleId == role.Id))
                .OrderBy(u => u.LastName + u.FirstName)
                .Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.LastName + ", " + u.FirstName
                })
            });
        }

        // POST: /Project/Create
        [Authorize(Roles = "canManageProjects")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ProjectController.Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }

        // GET: /Project/Details/Id
        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var model = await _context.Projects.AsNoTracking().SingleOrDefaultAsync(p => p.ProjectId == Id);
            return View(new DetailsViewModel { });
        }
    }
}