using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_BankingSolution
{
    internal class Current :Accounts
    {
        public bool ODIsEnabled { get; set; }

        public override double Withdraw(double withdrawAmount)
        {
            if ((withdrawAmount > AccBalance) && ODIsEnabled)
            {
                
                if((AccBalance -withdrawAmount) < -100000)
                {
                    throw new Exception("OD limit exeeded!!!");
                }
            }
            return base.Withdraw(withdrawAmount);
        }
    }
}
