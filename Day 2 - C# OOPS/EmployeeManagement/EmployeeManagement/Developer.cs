using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    internal class Developer : Employee
    {
        public override double CalculateBonus()
        {
            return empSalary * 0.1;
        }
        public override int ApplyLeaves(int noOfDaysLeaves)
        {
            if (noOfDaysLeaves > 5)
            {
                throw new Exception("Developer can apply max 5 leaves");
            }

            return base.ApplyLeaves(noOfDaysLeaves);
        }
    }
}
