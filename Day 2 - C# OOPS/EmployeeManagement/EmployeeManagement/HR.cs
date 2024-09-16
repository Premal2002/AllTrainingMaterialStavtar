using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class HR : Employee
    {
        public override double CalculateBonus()
        {
            return empSalary * 0.06;
        }
        public override int ApplyLeaves(int noOfDaysLeaves)
        {
            if (noOfDaysLeaves > 3)
            {
                throw new Exception("HR can apply max 3 leaves");
            }

            return base.ApplyLeaves(noOfDaysLeaves);
        }
    }
}
