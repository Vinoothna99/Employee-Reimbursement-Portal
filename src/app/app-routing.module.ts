import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { AdminGuard } from './Authenticate/admin.guard';
import { AuthenticateGuard } from './Authenticate/authenticate.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';

import { HomeAdminComponent } from './HomeAdmin/HomeAdmin.component';
import { AddEditComponent } from './HomeEmployee/add-edit/add-edit.component';
import { HomeEmployeeComponent } from './HomeEmployee/HomeEmployee.component';

const routes: Routes = [
  
  {path:'home-employee', component:HomeEmployeeComponent, canActivate:[AuthenticateGuard]},
  {path:'home-admin', component:HomeAdminComponent, canActivate:[AdminGuard]},
  
  {path:'home-employee', component:HomeEmployeeComponent, children: [
    {path:'add-edit', component:AddEditComponent, canActivate:[AuthenticateGuard] }
  ]},

  {path:'auth', component:AuthComponent},
  {path:'', component:AuthComponent},
  {path:'forbidden', component:ForbiddenComponent, canActivate:[AuthenticateGuard]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
