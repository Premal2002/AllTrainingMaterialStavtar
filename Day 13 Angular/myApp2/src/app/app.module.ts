import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DataBindingComponent } from './data-binding/data-binding.component';
import { FormsModule } from '@angular/forms';
import { DirectiveComponent } from './directive/directive.component';
import { EmployeeManagementSystemComponent } from './employee-management-system/employee-management-system.component';
import { TodoAppComponent } from './todo-app/todo-app.component';
import { ChildComponent } from './child/child.component';
import { DemoViewChildComponent } from './demo-view-child/demo-view-child.component';
import { StandaloneCompComponent } from './standalone-comp/standalone-comp.component';
import { RegisterComponentComponent } from './register-component/register-component.component';


@NgModule({
  declarations: [
    AppComponent,
    DataBindingComponent,
    DirectiveComponent,
    EmployeeManagementSystemComponent,
    TodoAppComponent,
    ChildComponent,
    DemoViewChildComponent,
    RegisterComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    StandaloneCompComponent
  ],
  providers: [
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
