using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
namespace HttpClient_Calls.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string? EmpName { get; set; }

        public int? DeptId { get; set; }

        public string? EmpDesignation { get; set; }

        public string? EmpCity { get; set; }

        public double? EmpSalary { get; set; }


    }
}
