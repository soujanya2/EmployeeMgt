using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmt.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectId { get; set; }
        [Required]
        public string? ProjectName { get; set; }

        public DateTime Duration { get; set; }
        
        [ForeignKey("department")]
        public int deptid { get; set; }
        public Department? department  { get; set; }
    }
}
