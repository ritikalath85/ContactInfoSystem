using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactInfoSystem.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string UserImageName { get; set; }
       
        public int CountryId { get; set; }


        public Country Country { get; set; }

        public int Gender { get; set; }
    }
}
