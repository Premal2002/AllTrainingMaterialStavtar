// See https://aka.ms/new-console-template for more information
using Linq_Demo;

//Console.WriteLine("Hello, World!");

#region List Data
List<Employee> empList = new List<Employee>()
{
    new Employee(){ EmpNumber = 100, EmpName="Premal", EmpDesignation="Developer", EmpCity="Thane", EmpSalary = 50000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 101, EmpName="Pratik", EmpDesignation="Tester", EmpCity="Mumbai", EmpSalary = 30000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 102, EmpName="Ganesh", EmpDesignation="HR", EmpCity="Delhi", EmpSalary = 20000, EmpIsPermanent= false },
    new Employee(){ EmpNumber = 103, EmpName="Sandip", EmpDesignation="Accountant", EmpCity="Thane", EmpSalary = 25000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 104, EmpName="Adarsh", EmpDesignation="HR", EmpCity="Thane", EmpSalary = 25000,  EmpIsPermanent= true },
    new Employee(){ EmpNumber = 105, EmpName="Chirag", EmpDesignation="Developer", EmpCity="Kolkata", EmpSalary = 60000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 106, EmpName="Hritik", EmpDesignation="Tester", EmpCity="Mumbai", EmpSalary = 40000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 107, EmpName="Sammer", EmpDesignation="Developer", EmpCity="Thane", EmpSalary = 50000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 108, EmpName="Harsh", EmpDesignation="Accountant", EmpCity="Pune", EmpSalary = 50000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 109, EmpName="Saurabh", EmpDesignation="Tester", EmpCity="Mumbai", EmpSalary = 70000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 110, EmpName="Mitesh", EmpDesignation="Developer", EmpCity="Delhi", EmpSalary = 50000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 111, EmpName="Rohit", EmpDesignation="Accountant", EmpCity="Thane", EmpSalary = 55000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 112, EmpName="Sanskar", EmpDesignation="Tester", EmpCity="Delhi", EmpSalary = 35000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 113, EmpName="Sanket", EmpDesignation="Developer", EmpCity="Thane", EmpSalary = 80000, EmpIsPermanent= true },
    new Employee(){ EmpNumber = 114, EmpName="Aniket", EmpDesignation="Accountant", EmpCity="Delhi", EmpSalary = 45000, EmpIsPermanent= true }

};
#endregion

#region Select
//var myEmp = (from e in empList
//             where e.EmpNumber == 100
//             select e).Single();

//Console.WriteLine(myEmp.EmpName);
//Console.WriteLine(myEmp.EmpSalary);
#endregion


//var myDevelopers = (from e in empList
//                    where e.EmpDesignation == "Developer"
//                    select e).ToList();

//foreach(var emp in myDevelopers)
//{
//    Console.WriteLine(emp.EmpName);
//}

//var permanentEmp = (from e in empList
//                    where e.EmpIsPermanent == true
//                    select e).ToList();

//foreach (var emp in permanentEmp)
//{
//    Console.WriteLine(emp.EmpName);
//}


//var totalPermanent = empList.Count(em => em.EmpIsPermanent == true);
//Console.WriteLine(totalPermanent);

//var totalSalary = (from e in empList
//                   where e.EmpCity == "Mumbai"
//                   select e.EmpSalary).Sum();
//Console.WriteLine(totalSalary);

//var sortedEmpWithSalary = (from e in empList
//                           orderby e.EmpSalary
//                           select e).ToList();
//foreach (var emp in sortedEmpWithSalary)
//{
//    Console.WriteLine(emp.EmpName);
//}

//var salaryDetails = (from e in empList
//                     where e.EmpIsPermanent == true
//                     select new { 
//                        Salary = e.EmpSalary,
//                        Bonus = e.EmpSalary * 0.1,
//                        Reward = e.EmpSalary * 0.4,
//                        Tax = e.EmpSalary * 0.8
//                     }).ToList();

//foreach (var emp in salaryDetails)
//{
//    Console.WriteLine(emp.Salary);
//    Console.WriteLine(emp.Bonus);
//    Console.WriteLine(emp.Tax); 
//    Console.WriteLine(emp.Reward);
//}




