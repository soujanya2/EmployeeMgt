using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Project>? pid { get; set; }
        public ICollection<Employee>? eid { get; set; }
    }
}
