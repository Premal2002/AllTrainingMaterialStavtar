using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Fundamentals
{
    internal class Calculations
    {
        //public int Add(int num1, int num2) {
        //    return num1 + num2;
        //}

        //public int Add(int num1, int num2,int num3)
        //{
        //    return num1 + num2 + num3;
        //}

        //public int Add(int num1, int num2,int num3,int num4)
        //{
        //    return num1 + num2 + num3 +4;
        //}

        public int Add(int num1, int num2, params int[] numbers)
        {
            int sum = num1 + num2;
            for (int i = 0; i < numbers.Length; i++) {
                sum += numbers[i];
            }
            return sum;
        }

        public double SimpleInterest(int principal, double roi, int duration)
        {
            double calculate = (((principal  * roi) / 100))* duration;
            return calculate;
        }

        public string Greetings(string name)
        {
            if(name =="")
            {
                throw new Exception("Please pass a valid name");
            }
            else if(name.Length < 3)
            {
                throw new Exception("Name should be minimum 3 characters");
            }

            return "Hello " + name + " welcome to my program";
        }
    }
}
