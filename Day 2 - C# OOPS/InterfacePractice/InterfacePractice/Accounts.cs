using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    internal class Accounts : ITransaction, IApply
    {
        public int Balance { get; set; }

        #region IApply-Implementation
        public string ApplyATM()
        {
            return "ATM applied";
        }

        public string ApplyChequeBook()
        {
            return "ChequeBook Applied";
        }
        #endregion


        #region ITransaction-Implementation
        public double Deposit(int amount)
        {
            Balance += amount;
            return Balance;
        }

        public double Withdraw(int amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}
