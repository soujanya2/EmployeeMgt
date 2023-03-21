using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMgmt.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public string? Gender { get; set; }
        [Key]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
        public string? designation { get; set; }
        [Required]

        public double Salary { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime DateOfJoining
        {
            get; set;

        }
        [ForeignKey("department")]
        public int Deptid { get; set; }
        public Department? department { get; set; }
    }
}
