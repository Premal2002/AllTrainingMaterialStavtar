using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    internal interface ITransaction
    {

        double Withdraw(int amount);

        double Deposit(int amount);
    }
}
