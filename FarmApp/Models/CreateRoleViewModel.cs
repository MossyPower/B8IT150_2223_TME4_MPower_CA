// kudventkat (2019) Extend IdentityUser in ASP NET Core. Available at: 
// https://www.youtube.com/watch?v=TuJd2Ez9i3I&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=78&ab_channel=kudvenkat

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