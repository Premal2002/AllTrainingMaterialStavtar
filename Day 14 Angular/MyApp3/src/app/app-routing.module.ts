import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { ProductFormComponent } from './product-form/product-form.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { ChildAComponent } from './dashboard/child-a/child-a.component';
import { ChildBComponent } from './dashboard/child-b/child-b.component';
import { AuthGuard } from './auth.guard';
import { LoginComponent } from './login/login.component';
import { TestGuardGuard } from './test-guard.guard';

const routes: Routes = [
  {path : '', redirectTo : "list", pathMatch : "full"},
  {path : 'list', component : ProductListComponent},
  {path : 'details/:id', component : SingleProductComponent},
  {path : 'login', component : LoginComponent},
  {path : 'addProduct', component : ProductFormComponent},
  {path : 'dashboard', component : DashboardComponent, canDeactivate : [TestGuardGuard], canActivate : [AuthGuard], canActivateChild : [AuthGuard] ,children : [
    {path : 'childa', component : ChildAComponent},
    {path : 'childb', component : ChildBComponent},
  ]},
  {path : 'customer', loadChildren : ()=> import("./customers/customers.module").then(m=>m.CustomersModule).catch(error=>error)},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
