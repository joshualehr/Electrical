using Electrical.Models;
using Electrical.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electrical.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "canAdminister")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Admin/UserIndex
        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            foreach (var item in _userManager.Users)
            {
                item.AllRoles = string.Join(", ", await _userManager.GetRolesAsync(item));
            }
            return View(new UserIndexViewModel() { Users = await _userManager.Users.ToListAsync() });
        }

        // GET: Admin/EditUser/(UserId)
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = new List<RoleCheckBox>();
            foreach (var role in await _roleManager.Roles.ToListAsync())
            {
                roles.Add(new RoleCheckBox {
                    Id = role.Id,
                    Name = role.Name,
                    IsChecked = await _userManager.IsInRoleAsync(user, role.Name)
                });
            }

            return View(new EditUserViewModel {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Company = user.Company,
                Title = user.Title,
                Trade = user.Trade,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Roles = roles
            });
        }

        // POST: Admin/EditUser/(UserId)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = await _userManager.FindByIdAsync(model.Id);
                if (userToUpdate == null)
                {
                    ModelState.AddModelError("", "Unable to save changes. The user has been deleted.");
                    return NotFound();
                }
                try
                {
                    await _userManager.UpdateAsync(userToUpdate);
                    await _userManager.SetEmailAsync(userToUpdate, model.Email);
                    await _userManager.SetUserNameAsync(userToUpdate, model.Email);
                    await _userManager.SetPhoneNumberAsync(userToUpdate, model.PhoneNumber);
                    try
                    {
                        foreach (var checkbox in model.Roles)
                        {
                            if (checkbox.IsChecked)
                            {
                                if (!await _userManager.IsInRoleAsync(userToUpdate, checkbox.Name))
                                {
                                    await _userManager.AddToRoleAsync(userToUpdate, checkbox.Name);
                                }
                            }
                            else
                            {
                                if (await _userManager.IsInRoleAsync(userToUpdate, checkbox.Name))
                                {
                                    await _userManager.RemoveFromRoleAsync(userToUpdate, checkbox.Name);
                                }
                            }
                        }
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        throw;
                    }
                    return RedirectToAction(nameof(AdminController.UserIndex));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
           // model.Roles.ToList();
            return View(model);
        }

        // POST: Admin/DeleteUser/(UserId)
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var data = await _userManager.FindByIdAsync(id);
            if (data == null)
            {
                return BadRequest();
            }

            var result = await _userManager.DeleteAsync(data);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(AdminController.UserIndex));
            }
            return NotFound();
        }

        // GET: Admin/RoleIndex
        [HttpGet]
        public async Task<IActionResult> RoleIndex()
        {
            return View(await _roleManager.Roles.AsNoTracking().ToListAsync());
        }

        // Get: Admin/CreateRole
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        // POST: Admin/CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AdminController.RoleIndex));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        // POST: Admin/DeleteRole/(RoleId)
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id, IdentityRole model)
        {
            try
            {
                var result = await _roleManager.DeleteAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(AdminController.RoleIndex));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Delete failed. Try again, and if the problem persists see your system administrator.");
            }
            return View(model);
        }
    }
}
