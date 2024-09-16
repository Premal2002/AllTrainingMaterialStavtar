using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_BankingSolution
{
    internal class Savings : Accounts
    {

        public override double Withdraw(double withdrawAmount)
        {
            if (withdrawAmount > 20000)
            {
                throw new Exception("You can withdraw max 20000");
            }
            else if (withdrawAmount > AccBalance) 
            {
                throw new Exception("Insufficient balance!!!");
            }

            return base.Withdraw(withdrawAmount);
        }
    }
}
