using Microsoft.AspNetCore.Identity;

namespace ContactInfoSystem.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }

}
