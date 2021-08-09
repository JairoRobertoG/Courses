using Microsoft.AspNetCore.Identity;

namespace Courses.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public UserRegister UserRegister { get; set; }
    }
}
