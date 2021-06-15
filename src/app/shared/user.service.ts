import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user.model';
import { getMaxListeners } from 'process';
import { ThisReceiver } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly rootUrl = 'https://localhost:44365';
  readonly PhotoUrl="https://localhost:44365/Photos";

  constructor(private http: HttpClient) { }

  registerUser(user: User){
    const body: User = {
      UserName : user.UserName,
      Email : user.Email,
      Password : user.Password,
      UserBankAccNo : user.UserBankAccNo,
      UserBankName : user.UserBankName,
      UserPAN : user.UserPAN

    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl+'/api/User/Register',body, {headers: reqHeader});
  }

  userAuthentication(userName,password){
    var data = "username=" +userName+"&password="+password+"&grant_type=password";
    var reqHeader = new HttpHeaders({'Conten-Type':'application/x-www-urlencoded', 'No-Auth':'True'});
    return this.http.post(this.rootUrl+'/token',data,{headers:reqHeader});
  }

  getUserClaims():Observable<any[]>{
    return this.http.get<any>(this.rootUrl+'/api/GetUserClaims');
    //,{headers:new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('userToken')})}
  }

  /*getUserClaims():Observable<any[]>{
    return this.http.get<any>(this.rootUrl+'/api/GetUserClaims');
  }*/

  getApprovedClaims():Observable<any[]>{
    return this.http.get<any>(this.rootUrl+'/api/GetApprovedClaims');
  }

  GetUserId(val:any):Observable<any>{
    return this.http.get<any>(this.rootUrl+'/api/GetUserId',val);
  }
  getDeclinedClaims():Observable<any[]>{
    return this.http.get<any>(this.rootUrl+'/api/GetDeclinedClaims');
  }

  AddClaim(val:any){
    return this.http.post(this.rootUrl+'/api/Employee',val)
  }
  UpdateClaim(val:any){
    return this.http.put(this.rootUrl+'/api/Employee',val)
  }

  DeleteClaim(val:any){
    return this.http.delete(this.rootUrl+'/api/Employee',val)
  }

  UploadPhoto(val:any){
    return this.http.post(this.rootUrl+'/api/Employee/SaveFile',val)
  }

}
