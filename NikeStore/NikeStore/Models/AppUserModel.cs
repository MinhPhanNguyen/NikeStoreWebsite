using Microsoft.AspNetCore.Identity;

namespace NikeStore.Models
{
    public class AppUserModel : IdentityUser
    {
        public string RoleId { get; set; }
    }
}
