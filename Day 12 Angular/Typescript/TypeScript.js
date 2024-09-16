// let fullName : string = "Premal Kadam";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
// const pi : number = 3.14;
// console.log(`Full Name : ${fullName}`);
// console.log("Pi value : "+ pi);
//----------------------------------------------------------------------------
//DATA TYPES
// let decimal : number = 10;
// let hex : number = 0xf00d;
// let binary : number = 0b1010;
// let octal : number = 0o744;
// console.log(`Decimal : ${decimal}, Hex: ${hex}, Binary: ${binary}, Octal: ${octal}`);
//other than number there are  : string, boolean, any, undefined & null ...
//-------------------------------------------------------------------------------------
// function logMessgae(msg : string){
//     console.log(msg);
// }
// logMessgae("Hello, my name is Premal.");
//----------------------------------------------------------------------------------------
//Array - collection of values of specific type
// let number : number[] = [1,2,3,4,5];
// let names : Array<string> = ["Premal","Sandip","Saurabh"];
// for(let i = 0;i<number.length;i++){
//     console.log(number[i]);
// }
// console.log();
// for (const element of names) {
//     console.log(element);
// }
//-------------------------------------------------------------------
//tuple : fixed size with fixed data types
// let user : [string,number,boolean] = ["Premal", 10,true]
// user.forEach(element => {
//   console.log(element);  
// });
//----------------------------------------------------------
//enum - fixed values variabes
//  enum color {
//     Red,
//     Green,
//     Blue
//  }
//  let backgroundColor : color = color.Green;
//  console.log(color[backgroundColor]);
//-----------------------------------------------------------
//objects - 
// let user : {name : string, age : number, email : string, city : string} = {
//     name : "John",
//     age : 30,
//     email : "prem@gmail,com",
//     city : "Thane"
// };
// for (const key in user) {
//    console.log(`${key} : ${user[key]}`);  // user[] for in loop
// }
//--------------------------------------------------------------------------------------------------
//Union types - can have multiple values
// let value : string | number | boolean  // | (pipe) is ued
// value = "prem";
// console.log(value);
// value = 11;
// console.log(value);
// value = false;
// console.log(value);
//---------------------------------------------------------------------
//literal type - can specify exact values that user can assign
// let myStatus : "success" | "failure";
// myStatus = "success";
// console.log(myStatus)
// // myStatus = "prem"; // error
//----------------------------------------------------------
//Type alias - you can create a custum types aliases to make code more readable
// type ID = number | string;
// let userID : ID = 123;
// let userName : ID = "Prem";
// console.log(`UserID : ${userID}, UserName : ${userName}`);
//--------------------------------------------------------------
//interfaces - used to define a structure of an object. Unlike type, it is mainly used to define an object type
// interface Person {
//     name: string,
//     age: number,
//     isEmployee: boolean
// }
// let employee: Person[] = [
//     {
//         name: "Prem",
//         age: 22,
//         isEmployee: true
//     },
//     {
//         name: "Sandip",
//         age: 23,
//         isEmployee: true
//     },
//     {
//         name: "Chirag",
//         age: 28,
//         isEmployee: false
//     },
// ]
// employee.forEach(element => {
//     //here we can also use for in
//     if(element.isEmployee == true)
//         console.log(`Name : ${element.name}, Age : ${element.age}, isEmployee : ${element.isEmployee}`);
// });
// const activeEmployees : Person[] = employee.filter(emp => emp.isEmployee == true); //filter to filter the values
// activeEmployees.forEach(element => {
//     console.log(`Name : ${element.name}, Age : ${element.age}, isEmployee : ${element.isEmployee}`);
// });
//--------------------------------------------------------------------------------------------------------------------
//functions - can be used to implement a small task. can define function parameter and return types in Typescript
// function add(num1 : number, num2: number) : number {
//     return num1 + num2;
// }
// console.log(add(100,200));
// function greet(name : string, greetings : string = "Hello") : string {
//     return `${greetings}, ${name}`;
// }
// console.log(greet("Premal"));
// function getFullName(firstName :string, middleName : string, lastName : string) : string {
//     return `${firstName} ${middleName} ${lastName}`;
// }
// console.log(getFullName("Premal","Subhash","Kadam"));
//----------------------------------------------------------------------------------------------
//class
// class Employee{
//     empNumber : number;
//     empName : string;
//     empSalary : number
//     constructor( empNumber : number, empName : string, empSalary : number){
//         this.empNumber = empNumber;
//         this.empName = empName;
//         this.empSalary =  empSalary; 
//      }
//      displayEmployee() : void {
//         console.log("Employee Number : "+ this.empNumber);
//         console.log("Employee Name : "+ this.empName);
//         console.log("Employee Salary : "+ this.empSalary);
//      }
// }
// let emp1 = new Employee(111,"Premal", 40000);
// let emp2 = new Employee(112,"Sandip", 50000);
// emp1.displayEmployee();
// emp2.displayEmployee();
// **** Note : by default it is converted into ecmascript 5
//             to convert into es6 : use tsc dataType.ts --target es6 while compiling
//----------------------------------------------------------------------------------------------
//TASK 
// class Account {
//     accHolderName : string;
//     accNo : number;
//     balance : number;
//     constructor(accHolderName : string,accNo : number,balance : number){
//         this.accHolderName = accHolderName;
//         this.accNo = accNo;
//         this.balance = balance;
//     }
//     getBalance() : number {
//         return this.balance;
//     }
//     getDetails() : void {
//         console.log("Account Holder Name : "+this.accHolderName);
//         console.log("Account Number : "+ this.accNo);
//         console.log("Account Balance : "+ this.balance); 
//     }
//     deposit(amount : number) : string{
//         this.balance += amount;
//         return "Amount Deposited Successfully.";
//     }
//     withdraw(amount:number) : string {
//         if(amount > this.balance){
//             return "Insufficient Balance!!!";
//         }
//         this.balance -= amount;
//         return "Amount Withdraw Successfully";
//     }
// }
// let account = new Account("Premal", 112, 50000);
// console.log("Current Account Balance : "+account.getBalance());
// console.log("------------------------------------------------");
// console.log("Account Details");
// account.getDetails();
// console.log("------------------------------------------------");
// console.log(account.deposit(10000));
// console.log("------------------------------------------------");
// console.log(account.withdraw(80000));
//---------------------------------------------------------------------------------
//Arrow functions 
// const multiply = (a:number, b:number) : number => a * b;
// console.log(multiply(5,4));
// const logMessage = (message : string) : void => console.log(message);
// logMessage("Hello, this is arrow functions");
// const add = (num1 : number, num2 : number) : number => {
//     let result = num1+num2;
//     return result;
// }
// console.log(add(200,500));
//---------------------------------------------------------------------------------
//Default parameter
// const greet = (name : string = "Premal") : string => `Hello ${name}`;
// console.log(greet());
// console.log(greet('Saurabh'));
//---------------------------------------------------------------------------------
//spread operator
//Rest parameter - in function parameter spread operator is called as rest parameter
// function sum(...numbers : number[]) : number {
//     let sum = 0;
//     for (let n of numbers) {
//         sum += n;
//     }
//     return sum;
// }
// console.log(sum(1,2,3));
// const sum = (...numbers : number[]) : number => {
//     return numbers.reduce((acc,curr) => acc + curr,0);
// };
// console.log(sum(1,2,3,4,5,6));
//------------------------------------------------------------------------
//Destructuring
// let fruits : string[] = ["Apple","Banana","cherry"];
// let[first, second, third] = fruits;
// console.log(first);
// console.log(second);
// console.log(third);
//element skipping
// let fruits : string[] = ["Apple","Banana","cherry"];
// let[first, , third] = fruits;
// console.log(first);
// console.log(third);
//rest operator
// let fruits : string[] = ["Apple","Banana","cherry"];
// let[first, ...others] = fruits;
// console.log(first);
// console.log(others);
//--------------------------------------------------------------------------------
//Object Destructuring
// let person = {fName : "Premal", age : 22, country : "INDIA"};
// let {fName,age,country} = person;
// console.log(fName);
// console.log(age);
// console.log(country);
//-------------------------------------------------------------------------
//variable rename
// let person = {fName : "Premal", age : 22, country : "INDIA"};
// let {fName : fullName,age ,country} = person;
// console.log(fullName);
// console.log(age);
// console.log(country);
//---------------------------------------------------------------------------
//Modules -  can be create to use them into another file
//using Account.js
// import { Employee } from "./Account";  // usually we do it at the top
// let emp1 = new Employee(111,"Premal", 40000);
//     let emp2 = new Employee(112,"Sandip", 50000);
//     emp1.displayEmployee();
//     emp2.displayEmployee();
//--------------------------------------------------------------------------
//Fetch api and Async and await
function fetchData() {
    return __awaiter(this, void 0, void 0, function* () {
        try {
            const response = yield fetch('https://jsonplaceholder.typicode.com/users');
            const json = yield response.json();
            console.log(json);
        }
        catch (error) {
            console.log(error);
        }
    });
}
fetchData();
