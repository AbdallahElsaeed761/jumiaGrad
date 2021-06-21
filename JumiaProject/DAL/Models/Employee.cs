using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Employee
    {
        [Key, ForeignKey("ApplicationUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EmployeeId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }

        public virtual applicationUser ApplicationUser { get; set; }

        public DateTime hireDate { get; set; } = DateTime.Now;

        [Required]
        public float Salary { get; set; }
    }
}