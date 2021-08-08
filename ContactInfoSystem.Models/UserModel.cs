using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserImageName { get; set; }
        public string Username { get; set; }
        public int CountryId { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string RoleName { get; set; }
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
