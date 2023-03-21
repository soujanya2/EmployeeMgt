using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int? Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public double? Salary { get; set; }

    public int Phoneno { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string? Manager { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; } = new List<EmployeeProject>();
}
