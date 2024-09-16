using OOPS_BankingSolution;

Savings savings = new Savings() { AccNo = 100, AccBalance = 10000, AccType = AccType.Savings, AccName = "Premal", AccIsActive = true};

Current current = new Current() { AccNo = 101, AccBalance = 10000, AccType = AccType.Current, AccName = "Sandip", AccIsActive = true, ODIsEnabled = true };

PF pF = new PF() { AccNo = 102, AccBalance = 10000, AccType = AccType.PF, AccName = "Saurabh", AccIsActive = true };

bool doTransaction = true;
try
{

    while (doTransaction)
    {

        Console.Clear();
        Console.WriteLine("Enter Amount to Withdraw");
        int amt = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("1. Savings Account ");
        Console.WriteLine("2. Current Account ");
        Console.WriteLine("3. PF Account");
        Console.WriteLine("4. Exit");
        int acctype = Convert.ToInt32(Console.ReadLine());
        switch (acctype)
        {
            case 1:
                Console.WriteLine(savings.Withdraw(amt));
                break;
            case 2:
                Console.WriteLine(current.Withdraw(amt));
                break;
            case 3:
                Console.WriteLine(pF.Withdraw(amt));
                break;
            case 4:
                Console.WriteLine("Thank you for Banking");
                doTransaction = false;
                break;
            default:
                Console.WriteLine("Sorry wrong choice, please enter again");
                break;
        }
        Console.ReadLine();
    }
}
catch (Exception es)
{
    Console.WriteLine(es.Message);
}



