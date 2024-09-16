"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Employee = void 0;
var Employee = /** @class */ (function () {
    function Employee(empNumber, empName, empSalary) {
        this.empNumber = empNumber;
        this.empName = empName;
        this.empSalary = empSalary;
    }
    Employee.prototype.displayEmployee = function () {
        console.log("Employee Number : " + this.empNumber);
        console.log("Employee Name : " + this.empName);
        console.log("Employee Salary : " + this.empSalary);
    };
    return Employee;
}());
exports.Employee = Employee;
// **** Note : by default it is converted into ecmascript 5
//             to convert into es6 : use tsc dataType.ts --target es6 while compiling
