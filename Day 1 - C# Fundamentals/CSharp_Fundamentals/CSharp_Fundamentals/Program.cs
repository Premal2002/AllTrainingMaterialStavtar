// See https://aka.ms/new-console-template for more information

#region First Code
//Console.WriteLine("Hello, World!");

//Console.WriteLine("My name is Premal and this is my very first C# language program");

//Console.WriteLine("Please Enter your name");
//string name = Console.ReadLine();
//Console.WriteLine("Welcome " + name + " its nice to meet you");
#endregion

//data types
//int,string,long,float,double,char,bool

using CSharp_Fundamentals;

#region Banking Application
//Console.WriteLine("*******Welcome to Banking*******");

//#region Variables
//string uName, uPass;
//double dummyUserBalance = 10000;
//int menuChoiceByUser = 0;

//#endregion
//Console.WriteLine("Please Enter Username");
//uName = Console.ReadLine();

//Console.WriteLine("Please Enter Password");
//uPass = Console.ReadLine();


//if(uName=="Premal" && uPass == "prem@1234")
//{
//    //For clearing screen
//    Console.Clear();
//    Console.WriteLine("Welcome " + uName);

//    #region Menu 
//    Console.WriteLine("1. Check Balance");
//    Console.WriteLine("2. Withdraw");
//    Console.WriteLine("3. Deposit");
//    Console.WriteLine("4. Transfer");
//    Console.WriteLine("5. Last 5 Transactions");
//    Console.WriteLine("6. Exit");
//    #endregion

//    menuChoiceByUser = Convert.ToInt32(Console.ReadLine());

//    #region SwitchCase
//    switch (menuChoiceByUser)
//    {
//        #region Case 1 - Check Balance
//        case 1:
//            Console.WriteLine("Available Balance is " + dummyUserBalance);
//            break;
//        #endregion
//        #region Case2 - Withdraw
//        case 2: 
//            Console.WriteLine("Please Enter the withdraw amount");
//            int withdrawAmount = Convert.ToInt32(Console.ReadLine());
//            dummyUserBalance = dummyUserBalance - withdrawAmount;
//            Console.WriteLine("Withdraw successful, new balance " + dummyUserBalance);
//            break;
//        #endregion
//        #region Case 3 - Deposit
//        case 3:
//            Console.WriteLine("Please Enter the amount to deposit");
//            int depositAmount = Convert.ToInt32(Console.ReadLine());
//            dummyUserBalance = dummyUserBalance + depositAmount;
//            Console.WriteLine("Deposit successful, new balance " + dummyUserBalance);
//            break;
//        #endregion
//        default:
//            Console.WriteLine("Please enter valid choice");
//            break;

//    }
//    #endregion
//}
//else
//{
//    Console.WriteLine("Invalid Credentials");
//}
#endregion

#region Calculations Class All Test Objects
Calculations calculations = new Calculations();
Console.WriteLine(calculations.Add(5, 4));

//Calculations calculations = new Calculations();
//try
//{
//    Console.WriteLine("Please enter your name");
//    string name = Console.ReadLine();
//    Console.WriteLine(calculations.Greetings(name));
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

Accounts accounts =  new Accounts(50,"Prem",AccountTyoe.Savings);

Accounts obj2 = new Accounts();
obj2.AccountNumber = 60;
obj2.AccountName = "Prem";
obj2.AccountBalance = 40000;
obj2.AccType = AccountTyoe.Savings;
obj2.IsActive = true;



