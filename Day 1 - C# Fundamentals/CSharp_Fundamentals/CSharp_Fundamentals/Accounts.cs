using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Fundamentals
{
    internal class Accounts
    {
        //properties
        //methods
        //constructors
        //enums
        //events
        //private variables

        public int AccountNumber { get; set; } 
        public string AccountName { get; set; }
        public double AccountBalance { get; set; }
        public AccountTyoe AccType { get; set; }
        public bool IsActive { get; set; }


        public Accounts(int accNo,string name,AccountTyoe typeOfAccount)
        {
            
        }

        public Accounts()
        {
            
        }
    }
}
