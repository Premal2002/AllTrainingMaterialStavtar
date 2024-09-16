import { Component } from '@angular/core';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-employee-management-system',
  templateUrl: './employee-management-system.component.html',
  styleUrls: ['./employee-management-system.component.css']
})
export class EmployeeManagementSystemComponent {
  employee : Employee = new Employee(1,'',0,'');

  employees : Employee[] = [];

  editForm : boolean = false;

  saveEmployee(){
    // console.log("test");
    
    const id = Math.floor(Math.random()*1000);
    this.employees.push(this.employee);
    alert("Employee saved succesfully");
    this.employee = new Employee(id,'',0,'');
  }

  changeCurrEmp(emp : Employee){
    this.employee.id = emp.id;
    this.employee.name = emp.name;
    this.employee.salary = emp.salary;
    this.employee.city = emp.city;
    this.editForm = true;
  }

  deleteEmployee(id : number){
    this.employees.forEach(element => {
      if(element.id == id){
        this.employees = this.employees.filter(element => element.id != id);  
      }
    });
  }

  editEmployee(id : number){
    console.log(id);
    
    this.employees.forEach(element => {
      if(element.id == id){
        element.salary = this.employee.salary;
        element.name = this.employee.name;
        element.city = this.employee.city;
      }
    });

    this.editForm = false;
    this.employee = new Employee(id,'',0,'');
  }


}
