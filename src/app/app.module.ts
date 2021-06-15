import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthComponent } from './auth/auth.component';

import {MatTabsModule} from '@angular/material/tabs';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';
import { UserService } from './shared/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ForbiddenComponent } from './forbidden/forbidden.component';

import { AuthenticateInterceptor } from './Authenticate/Authenticate.interceptor';
import { AdminGuard } from './Authenticate/admin.guard';
import { AuthenticateGuard } from './Authenticate/authenticate.guard';


import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HomeEmployeeComponent } from './HomeEmployee/HomeEmployee.component';
import { HomeAdminComponent } from './HomeAdmin/HomeAdmin.component';
import { AddEditComponent } from './HomeEmployee/add-edit/add-edit.component';


@NgModule({
  declarations: [		
    AppComponent,
    AuthComponent,
    
    ForbiddenComponent,
    
    
    
    
      HomeEmployeeComponent,
      HomeAdminComponent,
      AddEditComponent
   ],
  imports: [
    
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatToolbarModule,
    BrowserModule,
    CommonModule
  ],
  providers: [UserService, AuthenticateGuard,
  {
    provide: HTTP_INTERCEPTORS,
    useClass:AuthenticateInterceptor,
    multi:true
  },
  AdminGuard
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
