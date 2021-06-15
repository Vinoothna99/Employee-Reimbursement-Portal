import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../shared/user.model';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  user:User;
  isLoginError:boolean=false;
  isSigninError:boolean=false;
  emailPattern = "[a-z0-9._%+-]+@[a-z0-9.-]+\[a-z]{2,4}$";
  constructor(private userService : UserService, private router: Router) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form? : NgForm){
    if(form!=null)
    form.reset();
    this.user={
      UserName: '',
    Email: '',
    Password: '',
    UserPAN: '',
    UserBankAccNo: '',
    UserBankName: '',
    
    }
  }
  OnSubmit(form: NgForm){
    this.userService.registerUser(form.value)
    .subscribe((data:any)=>{
      if(data.Succeeded==true)
      this.resetForm(form);
    },
    (err:HttpErrorResponse)=>{
      this.isSigninError=true;
    });
  }

  Login(userName, password){
    this.userService.userAuthentication(userName,password).subscribe((data:any)=>{
      localStorage.setItem('userToken',data.access_token);
      localStorage.setItem('authUserName',userName);
      if(userName=="admin@gmail.com"){
        this.router.navigate(['/home-admin']);
      }else{
      this.router.navigate(['/home-employee']);
      }

    },
    (err:HttpErrorResponse)=>{
        this.isLoginError = true;
    });
  }

}
