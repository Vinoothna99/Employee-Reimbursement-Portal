import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../shared/user.service';

@Injectable({
  providedIn: 'root'
})

export class AdminGuard implements CanActivate {
  constructor(private router : Router, private userService:UserService){
    
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean  {
      if(localStorage.getItem('userToken')!=null){
      if(localStorage.getItem('authUserName')=="admin@gmail.com"){  
        return true ;  
      }
    }
        this.router.navigate(['/']);
        return false;
      
      
      
  }
  
}
