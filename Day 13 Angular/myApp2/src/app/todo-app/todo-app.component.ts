import { Component } from '@angular/core';
import { Todo } from '../todo.model';

@Component({
  selector: 'app-todo-app',
  templateUrl: './todo-app.component.html',
  styleUrls: ['./todo-app.component.css']
})
export class TodoAppComponent {
    todos : Todo[] = []; //initialoized with empty array[]
    task : string = '';

  saveTask(){
      if(this.task == ''){
        alert("task should not be empty")
      }else{
        const id :number = Math.floor(Math.random()*1000);
            this.todos.push(new Todo(id,this.task,'pending'));
            alert(this.task+" added");
            this.task = '';
      }  
  }

    onUpdate(id : number){
        this.todos.forEach(element => {
          if(element.id == id){
            element.status = 'completed';
          }
        });
    }

    onDelete(id : number){
      this.todos.forEach(element => {
        if(element.id == id){
          if(element.status != 'pending'){
            this.todos = this.todos.filter(element => element.id != id);
            return;
          }else{
            alert("Task not completed yet");
          } 
        }
      });
      
        
    }
}
