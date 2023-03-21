using System;
using System.Collections.Generic;

namespace EmployeeMgmt.Models;

public partial class EmployeeProject
{
    public int Epid { get; set; }

    public string? Empemail { get; set; }

    public int? ProjId { get; set; }

    public virtual Employee? EmpemailNavigation { get; set; }

    public virtual Project? Proj { get; set; }
}
