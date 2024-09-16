using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal abstract class Employee
    {
        public int empNo { get; set; }
        public string empName { get; set; }
        public double empSalary { get; set; }
        public EmpDesignation empDesignation { get; set; }
        public int empAvailableLeaves { get; set; }

        public virtual double CalculateBonus() {
            return 0;
        }

        public virtual int ApplyLeaves(int noOfDaysLeaves) {
            if(noOfDaysLeaves <= 0)
            {
                throw new Exception("Please enter valid number of days");
            }else if(noOfDaysLeaves > empAvailableLeaves)
            {
                throw new Exception("You have only " + empAvailableLeaves + " available leaves");
            }
            empAvailableLeaves = empAvailableLeaves - noOfDaysLeaves; ;
            return empAvailableLeaves;
        }
    }
}
