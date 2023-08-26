using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FarmApp.Models
{
    public class CreateRoleViewModel : IdentityUser
    {
        [Required]
        public string RoleName {get; set;}
    }
}