using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FarmApp.Models
{
    public class EditUserViewModel
    {
        // collection properties, to avoid null exception errors
        public EditUserViewModel()
        {
            Claims = new List<string>(); Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }

        public List<string> Claims {get; set;}
        public IList<string> Roles { get; set;}
    }
}