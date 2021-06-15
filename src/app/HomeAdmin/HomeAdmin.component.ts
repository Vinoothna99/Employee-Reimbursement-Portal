import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-HomeAdmin',
  templateUrl: './HomeAdmin.component.html',
  styleUrls: ['./HomeAdmin.component.css']
})
export class HomeAdminComponent implements OnInit {
  userName:string;
  EmployeeEmailFilter:string="";
  RequestTypeFilter:string="";
  ClaimListWithNoFilter:any=[];
  ModalTitle:string;
  ActivateAddEdit:boolean;
  userPendingClaims:any=[];
  userApprovedClaims:any=[];
  userDeclinedClaims:any=[];
  getClaims:any;
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.pendingClaimList();
    this.approvedClaimList();
    this.declinedClaimList();
    this.userName=localStorage.getItem('authUserName');
  }

  pendingClaimList(){
    this.userService.getUserClaims().subscribe((data:any)=>{
      this.userPendingClaims=data;
      this.ClaimListWithNoFilter=data;
    });
  }

  approvedClaimList(){
    this.userService.getApprovedClaims().subscribe((data:any)=>{
      this.userApprovedClaims=data;
    });
  }

  declinedClaimList(){
    this.userService.getDeclinedClaims().subscribe((data:any)=>{
      this.userDeclinedClaims=data;
    });
  }

  Logout(){
    localStorage.removeItem('userToken');
    this.router.navigate(['']);

  }

  
  FilterFn(){
    var EmployeeEmailFilter=this.EmployeeEmailFilter;
    var RequestTypeFilter=this.RequestTypeFilter;

    this.userPendingClaims=this.ClaimListWithNoFilter.filter(function (el){
      return el.this.userPendingClaims.UserName.toString().toLowerCase().includes(
        EmployeeEmailFilter.toString().trim().toLowerCase()
      )&&
      el.this.userPendingClaims.ClaimType.toString().trim.toLowerCase().includes(
        RequestTypeFilter.toString().trim().toLowerCase()
      )
      
    });
  }

  closeClick(){
    this.ActivateAddEdit=false;
    this.pendingClaimList();
    this.approvedClaimList();
    this.declinedClaimList();
  }

  approveClick(item){
    this.getClaims=item;
    this.ModalTitle="Approve Reimbursement Claim";
    this.ActivateAddEdit=true;
  }

  
  approveClaim(){
    var val={
     Id:this.getClaims.Id,
    UserId: this.getClaims.UserId,
    ClaimType: this.getClaims.ClaimType,
    ClaimValue: this.getClaims.ClaimValue,
    Currency: this.getClaims.Currency,
    Date: this.getClaims.Date,
    ReceiptPhotoFileName: this.getClaims.ReceiptPhotoFileName,
    ClaimPhase: "Processed",
    isApproved: "1",
    ApprovedBy: this.getClaims.ApprovedBy,
    ApprovedValue: this.getClaims.ApprovedValue,
    InternalNotes: this.getClaims.InternalNotes
    }

    this.userService.UpdateClaim(val).subscribe(res=>{
      alert(res.toString());
    });

    this.closeClick();
  }

  declineClaim(item){
    this.getClaims=item;
    var val={
      Id:this.getClaims.Id,
     UserId: this.getClaims.UserId,
     ClaimType: this.getClaims.ClaimType,
     ClaimValue: this.getClaims.ClaimValue,
     Currency: this.getClaims.Currency,
     Date: this.getClaims.Date,
     ReceiptPhotoFileName: this.getClaims.ReceiptPhotoFileName,
     ClaimPhase: "Processed",
     isApproved: "0",
     ApprovedBy: this.getClaims.ApprovedBy,
     ApprovedValue: this.getClaims.ApprovedValue,
     InternalNotes: this.getClaims.InternalNotes
     }
 

    this.userService.UpdateClaim(val).subscribe(res=>{
      alert(res.toString());
    });

    this.closeClick();
  }

}
