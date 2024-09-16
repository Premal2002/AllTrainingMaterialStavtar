
using System.Collections.Generic;

using EmployeeManagementSystem;

#region Employee Management System
//Console.WriteLine("************Employee Management System***********");

//int menuChoiceByUser;
//string empUserName,empPassword;

//Console.WriteLine("Please Enter Username");
//empUserName = Console.ReadLine();

//Console.WriteLine("Please Enter Password");
//empPassword = Console.ReadLine();

//if(empUserName == "Premal" && empPassword == "prem@1234")
//{
//    Console.Clear(); ;

//    Employee employee = new Employee();
//    employee.EmpNumber = 100;
//    employee.EmpName = "Premal";
//    employee.EmployeeDesignation = EmpDesignation.AssociateEngineer;
//    employee.EmpSalary = 40000;
//    employee.EmpIsActive = true;
//    employee.EmployeeGender = EmpGender.Male;
//    employee.EmpAvailableLeaves = 6;


//    Console.WriteLine("Welcome +" + employee.EmpName);

//    #region Employee Menu

//    Console.WriteLine("1. Get Employee Name, Designation and Salary");
//    Console.WriteLine("2. Calculate Bonus");
//    Console.WriteLine("3. Apply For Leaves");

//    #endregion

//    menuChoiceByUser = Convert.ToInt32(Console.ReadLine());

//    switch (menuChoiceByUser)
//    {
//        case 1:
//            employee.EmployeeDetails();
//            break;
//        case 2:
//            try
//            {
//                Console.WriteLine("Enter Bonus Percentage for Employee");
//                int bonusPercentage = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine("Bonus Salary : " + employee.CalculateBonus(bonusPercentage));
//            }catch(Exception ex) 
//            {
//                Console.WriteLine(ex.Message);
//            }
//            break;
//        case 3:
//            try
//            {
//                Console.WriteLine("How many days leaves you want");
//                int noOfDaysLeaves = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine(employee.ApplyLeave(noOfDaysLeaves,EmpLeaveType.Casual));
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            break;
//        default:
//            Console.WriteLine("Please enter valid choice");
//            break;

//    }
//}
#endregion

List<string> list = new List<string>();
    list.Add("Premal");
    list.Add("Sandip");
    Console.Write(list);









