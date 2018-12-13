using Microsoft.AspNetCore.Identity;

namespace TimeSheet.Models
{
    public class Role : IdentityRole
    {
        public Role(string roleName) : base(roleName)
        {

        }
    }
}
