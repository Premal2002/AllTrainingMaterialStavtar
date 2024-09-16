using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_BankingSolution
{
    internal class PF : Accounts
    {

        //can withdraw max 60%

        public override double Withdraw(double withdrawAmount)
        {
            if (withdrawAmount > (AccBalance * 0.6))
            {
                throw new Exception("Sorry you can only withdraw max " + AccBalance * 0.6);
            }
            return base.Withdraw(withdrawAmount);
        }
    }
}
