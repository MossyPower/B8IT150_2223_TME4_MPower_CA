using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FarmApp.Controllers;

public class AdministrationController : Controller
{
    [Authorize(Roles = "Administrator")]
    public IActionResult Index()
    {
        return View();
    }
}
