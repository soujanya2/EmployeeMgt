using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Models;

public partial class Department
{
    public int Deptid { get; set; }

    public string Deptname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<Project> Projects { get; } = new List<Project>();
}
