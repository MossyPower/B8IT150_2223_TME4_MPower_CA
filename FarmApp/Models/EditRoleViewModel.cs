// kudventkat (2019) Edit role in asp net core. Available at:
// https://www.youtube.com/watch?v=7ikyZk5fGzk&ab_channel=kudvenkat 

using System.ComponentModel.DataAnnotations;

namespace FarmApp.Models
{
    public class EditRoleViewModel
    {
        //Propperties from Role 
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id {get; set;}

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName {get; set;}

        public List<string> Users {get; set;}

    }
}