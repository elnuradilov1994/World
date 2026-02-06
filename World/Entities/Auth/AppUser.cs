using Microsoft.AspNetCore.Identity;

namespace World.Entities.Auth
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
