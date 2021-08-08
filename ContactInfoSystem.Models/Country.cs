using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactInfoSystem.Models
{

    public class Country
    {
        public Country()
        {
            CreatedOn = DateTime.Now;
            CreatedBy = 1;
            DeletedFlag = false;
        }
        [Key]
        public int CountryId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string CountryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Boolean DeletedFlag { get; set; }
    }
}
