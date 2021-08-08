using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactInfoSystem.Models
{
    public class Designation
    {
        public Designation()
        {
            CreatedOn = DateTime.Now;
            CreatedBy = 1;
            DeletedFlag = false;
        }

        [Key]
        public int DesignationId { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string DesignationName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Boolean DeletedFlag { get; set; }
    }
}
