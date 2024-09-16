namespace EmployeeManagementSystem_InMemory_
{
    public class Employee
    {
        #region Properties
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
        #endregion

        #region Private Data
        private static List<Employee> empList = new List<Employee>() 
        {
            new Employee(){ EmpId = 1, EmpName = "Premal", EmpDesignation = "Developer", EmpCity = "Thane", EmpSalary = 40000 },
            new Employee(){ EmpId = 2, EmpName = "Rajesh", EmpDesignation = "Manager", EmpCity = "Mumbai", EmpSalary = 75000 },
            new Employee(){ EmpId = 3, EmpName = "Anita", EmpDesignation = "Analyst", EmpCity = "Pune", EmpSalary = 55000 },
            new Employee(){ EmpId = 4, EmpName = "Sita", EmpDesignation = "Designer", EmpCity = "Navi Mumbai", EmpSalary = 60000 },
            new Employee(){ EmpId = 5, EmpName = "Amit", EmpDesignation = "Tester", EmpCity = "Kalyan", EmpSalary = 45000 },
            new Employee(){ EmpId = 6, EmpName = "Meera", EmpDesignation = "HR", EmpCity = "Thane", EmpSalary = 50000 },
            new Employee(){ EmpId = 7, EmpName = "Vikram", EmpDesignation = "Project Lead", EmpCity = "Nashik", EmpSalary = 80000 },
            new Employee(){ EmpId = 8, EmpName = "Neha", EmpDesignation = "Database Administrator", EmpCity = "Aurangabad", EmpSalary = 65000 },
            new Employee(){ EmpId = 9, EmpName = "Sanjay", EmpDesignation = "System Analyst", EmpCity = "Kolhapur", EmpSalary = 57000 },
            new Employee(){ EmpId = 10, EmpName = "Ritika", EmpDesignation = "Marketing Specialist", EmpCity = "Jalgaon", EmpSalary = 52000 }

        };
        #endregion

        #region Methods
        #region Get Methods
        #region List of Employees
        public List<Employee> AllEmployees()
        {
            return empList;
        }
        #endregion
        #region EmployeeById
        public Employee EmployeeById(int id)
        {
            var Emp = (from e in empList
                       where e.EmpId == id
                       select e).SingleOrDefault();
            if (Emp == null)
            {
                throw new Exception("Employee with id +" + id + " not found");
            }
            return Emp;
        }
        #endregion
        #region EmployeesByDesignation
        public List<Employee> EmployeesByDesignation(string designation)
        {
            var Emp = (from e in empList
                       where e.EmpDesignation == designation
                       select e).ToList();
            if (Emp.Count() == 0)
            {
                throw new Exception("Employee with designation +" + designation + " not found in the Employee list");
            }
            return Emp;
        }
        #endregion
        #region EmployeesByCity
        public List<Employee> EmployeesByCity(string city)
        {
            var Emp = (from e in empList
                       where e.EmpCity == city
                       select e).ToList();
            if (Emp.Count() == 0)
            {
                throw new Exception("Employee with city +" + city + " not found in the Employee list");
            }
            return Emp;
        }
        #endregion
        #region TotalEmployeeCount
        public int TotalEmployeeCount()
        {
            return empList.Count;
        }
        #endregion
        #endregion
        #region Add, Update, Delete Methods
        #region Add Employee
        public string AddEmployee(Employee emp)
        {
            if (emp.EmpName.Length < 3)
            {
                throw new Exception("Please enter valid Employee name(Atleast more that 3 characters)");
            }
            empList.Add(emp);
            return "Employee Added successfully";
        }

        #endregion
        #region Delete Employee
        public string DeleteEmployee(int id)
        {
            var emp = (from e in empList
                       where e.EmpId == id
                       select e).SingleOrDefault();
            if (emp == null)
            {
                throw new Exception("Employee with id +" + id + " not found");
            }
            empList.Remove(emp);
            return "Employee removed successfully";
        }

        #endregion
        #region Modify Employee Details
        public string ModifyEmployee(Employee emp)
        {
            var Emp = (from e in empList
                       where e.EmpId == emp.EmpId
                       select e).SingleOrDefault();
            if(Emp == null)
            {
                throw new Exception("Employee with id +" + emp.EmpId + " not found");
            }

            Emp.EmpName = emp.EmpName;
            Emp.EmpDesignation = emp.EmpDesignation;
            Emp.EmpCity = emp.EmpCity;
            Emp.EmpSalary = emp.EmpSalary;
            return "Employee Details updated successfully";
        }

        #endregion
        #endregion
        #endregion
    }
}

#region

#endregion