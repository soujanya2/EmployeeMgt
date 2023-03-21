using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Projectname { get; set; } = null!;

    public DateTime? Duration { get; set; }

    public int? Did { get; set; }

    public virtual Department? DidNavigation { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; } = new List<EmployeeProject>();
}
