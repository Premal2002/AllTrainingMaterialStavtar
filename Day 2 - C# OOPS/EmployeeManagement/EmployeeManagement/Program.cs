// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using EmployeeManagement;

Developer developer = new Developer() { empNo = 100, empAvailableLeaves = 10, empDesignation = EmpDesignation.Developer, empName = "Premal", empSalary = 50000 };

HR hr = new HR() { empNo = 101, empAvailableLeaves = 10, empDesignation = EmpDesignation.HR, empName = "Sandip", empSalary = 30000 };

Accounts accounts = new Accounts() { empNo = 102, empAvailableLeaves = 10, empDesignation = EmpDesignation.Accounts, empName = "Saurabh", empSalary = 25000 };

bool flag1 = true;

try
{
    while (flag1)
    {
        Console.Clear();
        Console.WriteLine("Choose Operation");
        Console.WriteLine("1.Apply For Leaves");
        Console.WriteLine("2.Calculate Bonus");
        Console.WriteLine("3.Exit");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter no of days for applying leave");
                int noOfDaysLeave = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("1.Developer");
                Console.WriteLine("2.HR");
                Console.WriteLine("3.Accounts");
                int choice2 = Convert.ToInt32(Console.ReadLine());
                switch (choice2)
                {
                    case 1:
                        Console.WriteLine(developer.ApplyLeaves(noOfDaysLeave));
                        break;
                    case 2:
                        Console.WriteLine(hr.ApplyLeaves(noOfDaysLeave));
                        break;
                    case 3:
                        Console.WriteLine(accounts.ApplyLeaves(noOfDaysLeave));
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
                break;
            case 2:
                Console.WriteLine("1.Developer");
                Console.WriteLine("2.HR");
                Console.WriteLine("3.Accounts");
                int choice3 = Convert.ToInt32(Console.ReadLine());
                switch (choice3)
                {
                    case 1:
                        Console.WriteLine(developer.CalculateBonus());
                        break;
                    case 2:
                        Console.WriteLine(hr.CalculateBonus());
                        break;
                    case 3:
                        Console.WriteLine(accounts.CalculateBonus());
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
                break;
            case 3:
                Console.WriteLine("Thnak ypu for interacting");
                flag1 = false;
                break;
            default:
                Console.WriteLine("Please enter a valid choice");
                break;
        }
        Console.ReadLine();
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

