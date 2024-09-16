using System;
using System.Collections.Generic;

namespace EmployeeManagementSystemAPI.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public int? DeptId { get; set; }

    public string? EmpDesignation { get; set; }

    public string? EmpCity { get; set; }

    public double? EmpSalary { get; set; }
}
