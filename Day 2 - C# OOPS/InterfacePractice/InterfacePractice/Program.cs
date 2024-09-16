// See https://aka.ms/new-console-template for more information


using InterfacePractice;

ITransaction transaction = new Accounts();

Console.WriteLine(transaction.Deposit(10000));
