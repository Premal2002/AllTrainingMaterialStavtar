using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Accounts : Employee
    {
        public override double CalculateBonus()
        {
            return empSalary * 0.12;
        }

        public override int ApplyLeaves(int noOfDaysLeaves)
        {
            if (noOfDaysLeaves > 1)
            {
                throw new Exception("Accountant can apply max 1 leaves");
            }

            return base.ApplyLeaves(noOfDaysLeaves);
        }
    }
}
