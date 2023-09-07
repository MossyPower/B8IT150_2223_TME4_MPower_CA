// kudventkat (2019) Creating roles in asp net core. Available at: 
// https://www.youtube.com/watch?v=TuJd2Ez9i3I&ab_channel=kudvenkat 

namespace FarmApp.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}