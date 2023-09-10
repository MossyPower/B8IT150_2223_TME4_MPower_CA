using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FarmApp.Models;
using FarmApp.Data;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace FarmApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            PrivacyModel privacyDesc = _context.PrivacyModel.FirstOrDefault();

            return View(privacyDesc);
        }
        
        // Return EditPrivacy View
        public IActionResult EditPrivacy()
        {
            return View();
        }

        // Edit Privacy
        // [HttpPut("{id}")]
        // public async Task<IActionResult> EditPrivacy(int id, PrivacyModel privacyModel)
        // {
        //     // Retrive existing description from the Db
        //     var desc = _context.PrivacyModel.FirstOrDefault();


        //     if (id != privacyModel.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(privacyModel).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!EditPrivacyExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //     //return NoContent();
        //     return RedirectToAction("Privacy", "Home");
        // }

        // 5. Edit User Role 
        [HttpPost]
        public async Task<IActionResult> EditPrivacy(PrivacyModel model)
        {
            // retrive role from database
            //var role = await _context.PrivacyModel.FindByIdAsync(model.Id);
            var desc = _context.PrivacyModel.FirstOrDefault();
            
            // Check if role exists. If role does not exist, return not found message
            if(desc == null)
            {
                ViewBag.ErrorMessage = $"Description cannot be found";
                return View("NotFound");
            }
            else
            {
                // Change the role Name
                desc.Description = model.Description;

                // update role in database
                await _context.SaveChangesAsync();
            }
            //return NoContent();
            return RedirectToAction("Privacy", "Home");


                // // Check if update successful
                // if(result.Succeeded)
                // {
                //     return RedirectToAction("ListRoles");
                // }
                
                // // catch any errors
                // foreach(var error in result.Errors)
                // {
                //     ModelState.AddModelError("",error.Description);
                // }
                
                // // re-render if any validation errors
                // return View(model);
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // private bool EditPrivacyExists(int id)
        // {
        //     return (_context.PrivacyModel?.Any(e => e.Id == id)).GetValueOrDefault();
        // }
    }
}
