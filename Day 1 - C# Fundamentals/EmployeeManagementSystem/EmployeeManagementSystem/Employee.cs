using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    internal class Employee
    {
        #region Properties
        public int EmpNumber { get; set; }
        public string EmpName { get; set; }
        public EmpDesignation EmployeeDesignation { get; set; }
        public double EmpSalary { get; set; }
        public bool EmpIsActive { get; set; }
        public EmpGender EmployeeGender { get; set; }
        public int EmpAvailableLeaves { get; set; }
        #endregion

        #region Methods
        public double CalculateBonus(int bonusPercentage)
        {
            if (bonusPercentage > 10 || bonusPercentage < 4)
            {
                throw new Exception("Bonus Percentage should be in between 3 to 10");
            }

            double bonusSalary =  (EmpSalary/100) * bonusPercentage;
            Console.WriteLine(bonusSalary);

            return bonusSalary;
        }

        public int ApplyLeave(int noOfDaysForLeave , EmpLeaveType leaveType) 
        {
            if(noOfDaysForLeave > EmpAvailableLeaves)
            {
                throw new Exception("You cannot have that many leaves");
            }

            EmpAvailableLeaves = EmpAvailableLeaves - noOfDaysForLeave;
            return EmpAvailableLeaves;
        }

        public void EmployeeDetails()
        {
            Console.WriteLine("Employee Name : " + EmpName);
            Console.WriteLine("Employee Designation : " + EmployeeDesignation);
            Console.WriteLine("Employee Salary : " + EmpSalary);
        }
        #endregion

    }
}
