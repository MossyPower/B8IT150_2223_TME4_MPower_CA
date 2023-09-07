using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FarmApp.Models;

namespace FarmApp.Controllers
{
    // kudventkat (2019) Creating roles in asp net core. Available at: 
    // https://www.youtube.com/watch?v=TuJd2Ez9i3I&ab_channel=kudvenkat 
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
        
        // Kudvenkat (2019) Delete identity user in asp net core. Available at: https:
        // www.youtube.com/watch?v=MhNfyZGfY-A&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=86&ab_channel=kudvenkat 
        // Delete User
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            // check if id from url is contained in the users Database
            var user = await userManager.FindByIdAsync(id);

            // Check if role exists. If role does not exist, return 'Not Found' message
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                // If id is found, delete the user
                var result = await userManager.DeleteAsync(user);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(ListUsers);
            }
        }
        
        // Kudvenkat (2019) Delete identity role in asp net core. Available at: https:
        // www.youtube.com/watch?v=pj3GCelrIGM&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=88&ab_channel=kudvenkat 
        // Delete Role
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            // check if id from url is contained in the users Database
            var role = await roleManager.FindByIdAsync(id);

            // Check if role exists. If role does not exist, return 'Not Found' message
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                // If id is found, delete the user
                var result = await roleManager.DeleteAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(ListRoles);
            }
        }
        
        // Return : Administration Portal View
        public IActionResult Index()
        {
            return View();
        }
        
        // kudventkat (2019) List all users from asp net core identity database. Available at:  https:
        // www.youtube.com/watch?v=OMX0UiLpMSA&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=84&ab_channel=kudvenkat 
        // Return : ListUsers View
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }
        
        // Kudvenkat (2019) Edit identity user in asp net core. Available at: https:
        // www.youtube.com/watch?v=QYlIfH8qyrU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=85&ab_channel=kudvenkat 
        // Return: EditUser View
        [HttpGet]
        public async Task<IActionResult> EditUser(string id) //id passed in from Url
        {
            // check if id from url is contained in the users Database
            var user = await userManager.FindByIdAsync(id);

            // Check if role exists. If role does not exist, return not found message
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            
            // Retrive Claims & Roles data from underlying database. initialise the values in the userClaims & userRoles variables
            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            // Retrive the user Id and Name that you want to edit, using the userManager injection  
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };
            return View(model);
        }
        
        // Kudvenkat (2019) Edit identity user in asp net core. Available at: https:
        // www.youtube.com/watch?v=QYlIfH8qyrU&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=85&ab_channel=kudvenkat 
        // Edit User
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model) //id passed in from Url
        {
            // check if id from url is contained in the users Database
            var user = await userManager.FindByIdAsync(model.Id);

            // Check if role exists. If role does not exist, return not found message
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await userManager.UpdateAsync(user);

                if(result.Succeeded)
                {
                    return RedirectToAction("Listusers");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        
        // kudventkat (2019) Creating roles in asp net core. Available at: 
        // https://www.youtube.com/watch?v=TuJd2Ez9i3I&ab_channel=kudvenkat 
        // Return : CreateRole View
        [HttpGet]
        public IActionResult CreateRole()
        {
            // return the CreateRole view
            return View();
        }

        // kudventkat (2019) Creating roles in asp net core. Available at: 
        // https://www.youtube.com/watch?v=TuJd2Ez9i3I&ab_channel=kudvenkat 
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
        
        // kudventkat (2019) Get list of roles in asp core net. 
        // Available at: https://www.youtube.com/watch?v=KGIT8P29jf4&ab_channel=kudvenkat 
        // Return List Roles view
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        // kudventkat (2019) Edit role in asp net core. Available at:
        // https://www.youtube.com/watch?v=7ikyZk5fGzk&ab_channel=kudvenkat 
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
        
        // kudventkat (2019) Edit role in asp net core. Available at:
        // https://www.youtube.com/watch?v=7ikyZk5fGzk&ab_channel=kudvenkat 
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
        
        // kudventkat (2019) Edit role in asp net core. Available at:
        // https://www.youtube.com/watch?v=7ikyZk5fGzk&ab_channel=kudvenkat 
        // Return EditUsersInRole View
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            // Pass role Id to the view
            ViewBag.roleId = roleId;
            
            // retrive role from Identity database
            var role = await roleManager.FindByIdAsync(roleId);

            // Check if role exists. If role does not exist, return not found message
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            
            //create an instance of the rolemodel calss
            var model = new List<UserRoleViewModel>();


            foreach(var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        // kudventkat (2019) Add or remove users from role in asp net core. Available at: https:
        // www.youtube.com/watch?v=TzhqymQm5kw&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=81&ab_channel=kudvenkat 
        // Update Users RoleId (ref the EditUsersInRole View)
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            // retrive role from Identity database
            var role = await roleManager.FindByIdAsync(roleId);

            // Check if role exists. If role does not exist, return not found message
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            // loop through each user view model passed in via the model parameter
            for(int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if(model[i].IsSelected && !await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                
                if(result.Succeeded)
                {
                    if(i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId});
                }
            }
            return RedirectToAction("EditRole", new { Id = roleId});
        }
    }
}