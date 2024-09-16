 export class Employee{
        empNumber : number;
        empName : string;
        empSalary : number
        constructor( empNumber : number, empName : string, empSalary : number){
            this.empNumber = empNumber;
            this.empName = empName;
            this.empSalary =  empSalary; 
         }
    
         displayEmployee() : void {
            console.log("Employee Number : "+ this.empNumber);
            console.log("Employee Name : "+ this.empName);
            console.log("Employee Salary : "+ this.empSalary);
         }
    }
    
    
    
    // **** Note : by default it is converted into ecmascript 5
    //             to convert into es6 : use tsc dataType.ts --target es6 while compiling