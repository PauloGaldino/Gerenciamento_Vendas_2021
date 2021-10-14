using Microsoft.AspNetCore.Identity;

namespace Entity.Persons.Identity.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
