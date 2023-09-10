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
            return View();
        }
        // Return EditPrivacy View
        public IActionResult EditPrivacy()
        {
            return View();
        }

        // Edit Privacy
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPrivacy(int id, PrivacyModel privacyModel)
        {
            if (id != privacyModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(privacyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditPrivacyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return NoContent();
            return RedirectToAction("Privacy", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool EditPrivacyExists(int id)
        {
            return (_context.PrivacyModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
