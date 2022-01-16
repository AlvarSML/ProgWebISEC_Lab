using ASP6_SinAuth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace ASP6_SinAuth.Models.ViewModels
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}
