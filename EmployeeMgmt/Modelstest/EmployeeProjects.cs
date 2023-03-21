using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMgmt.Models
{
    public class EmployeeProjects
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("employee")]
        public string empemail { get; set; }
        [ForeignKey("project")]
        public int pid { get; set; }
        public Employee employee { get; set; }
        public Project project { get; set; }
    }
}
