using Microsoft.AspNetCore.Identity;

namespace Game.DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAgree;
    }
}
