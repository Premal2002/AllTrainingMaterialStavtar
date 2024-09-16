using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Demo
{
    [Serializable]// so the object can be moved from RAM to other places like disk or network
    public class Accounts
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double Accountbalance { get; set; }
        public bool AccountIsActive { get; set; }
        public string AccountType { get; set; }

        public double Withdraw(int amt)
        {
            Accountbalance = Accountbalance - amt;
            return Accountbalance;
        }

        public double Deposit(int amt)
        {
            Accountbalance = Accountbalance + amt;
            return Accountbalance;
        }


    }
}
