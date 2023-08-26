using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FarmApp.Models;
using FarmApp.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FarmApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        // Return : Administration Portal View
        public IActionResult Index()
        {
            return View();
        }
        
        // Return : CreateRole View
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        // Create new role
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "AdministrationController");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        
        // Return List Roles view
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        // Return Edit Roles view
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            // Check if role exists. If role does not exist, return not found message
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            // Retrive the user Id and Name that you want to edit, using the userManager injection  
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrive all users from the DB
            foreach(var user in userManager.Users)
            {
               if (await userManager.IsInRoleAsync(user, role.Name))
               {
                    model.Users.Add(user.UserName);
               }
            }
            return View(model);
        }

        // Edit user role 
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            // retrive role from database
            var role = await roleManager.FindByIdAsync(model.Id);

            // Check if role exists. If role does not exist, return not found message
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                // Change the role Name
                role.Name = model.RoleName;

                // update role in database
                var result = await roleManager.UpdateAsync(role);

                // Check if update successful
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                
                // catch any errors
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
                
                // re-render if any validation errors
                return View(model);
            }
        }
    }
}