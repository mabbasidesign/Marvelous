using Microsoft.AspNetCore.Identity;

namespace Marvelous.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
