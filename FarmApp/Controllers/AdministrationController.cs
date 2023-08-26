using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FarmApp.Models;

namespace FarmApp.Controllers;

[Authorize(Roles = "Administrator")]
public class AdministrationController : Controller
{
    // private readonly RoleManager<IdentityRole> roleManager;
    // private readonly UserManager<ApplicationUser> userManager;

    // public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    // {
    //     this.roleManager = roleManager;
    //     this.userManager = userManager;
    // }
    
    public IActionResult Index()
    {
        return View();
    }

    // [HttpGet]
    // public IActionResult CreateRole()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    // {
    //     return null;
    // }

}
