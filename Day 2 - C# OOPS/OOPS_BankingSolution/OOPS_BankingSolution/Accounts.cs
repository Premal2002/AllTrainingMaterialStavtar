using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_BankingSolution
{

    enum AccType
    {
        Savings, Current, PF
    }
    internal abstract class Accounts
    {

        public int AccNo { get; set; }
        public string AccName { get; set; }
        public AccType AccType { get; set; }
        public double AccBalance { get; set; }
        public bool AccIsActive { get; set; }

        #region Methods

        public virtual double Withdraw(double withdrawAmount)
        {
            if (withdrawAmount < 0) 
            {
                throw new Exception("Please do not enter negative value");
            }
            AccBalance = AccBalance - withdrawAmount;
            return AccBalance;
        }

        public double Deposit(int depositAmount)
        {
            AccBalance = AccBalance + depositAmount;
            return AccBalance;
        }

        #endregion
    }
}
