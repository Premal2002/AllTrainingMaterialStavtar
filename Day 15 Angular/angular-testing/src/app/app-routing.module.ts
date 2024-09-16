import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UserformComponent } from './user/userform/userform.component';
import { UserlistComponent } from './user/userlist/userlist.component';
import { UserdetailComponent } from './user/userdetail/userdetail.component';

const routes: Routes = [
  {path : '',component : HomeComponent},
  {path : 'about',component : AboutComponent},
  {path : 'addUser',component : UserformComponent},
  {path : 'userList',component : UserlistComponent},
  {path : 'details/:id',component : UserdetailComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
