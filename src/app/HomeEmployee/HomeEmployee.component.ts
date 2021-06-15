import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GetClaims } from '../shared/get-claims.model';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-HomeEmployee',
  templateUrl: './HomeEmployee.component.html',
  styleUrls: ['./HomeEmployee.component.css']
})
export class HomeEmployeeComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) { }
  rx = "^[0-9]+(\.[0-9]{1,2})$";

  EmployeeEmailFilter:string="";
  RequestTypeFilter:string="";
  ClaimListWithNoFilter:any=[];
  userName:string;
  ModalTitle:string;
  ActivateAddEdit:boolean;
  userClaims:any=[];
  getClaims:any;
  PhotoFilePath:string;
  ngOnInit():void {
    this.refreshClaimList();
    this.userName=localStorage.getItem('authUserName');
   
  }

  refreshClaimList(){
    this.userService.getUserClaims().subscribe((data:any)=>{
      this.userClaims=data;
      this.ClaimListWithNoFilter=data;
    });
  }

  FilterFn(){
    var EmployeeEmailFilter=this.EmployeeEmailFilter;
    var RequestTypeFilter=this.RequestTypeFilter;

    this.ClaimListWithNoFilter=this.ClaimListWithNoFilter.filter(function (el){
      return el.this.userClaims.UserName.toString().toLowerCase().includes(
        EmployeeEmailFilter.toString().trim().toLowerCase()
      )&&
      el.this.userClaims.ClaimType.toString().trim.toLowerCase()
      
    });
  }

  Logout(){
    localStorage.removeItem('userToken');
    this.router.navigate(['']);

  }

  addClick(){
    this.getClaims={
      Id:0,
      ClaimPhase:"To Be Processed",
      UserId:this.userName,
      ClaimType: "",
      ClaimValue: "",
      Currency: "",
      Date: "",
      ReceiptPhotoFileName: "",
    
      isApproved: "",
      ApprovedBy: "",
      ApprovedValue: "",
      InternalNotes: ""
      
    }

    this.ModalTitle="Add New Reimbursement Claim";
    this.ActivateAddEdit=true;
  }

  closeClick(){
    this.ActivateAddEdit=false;
    this.refreshClaimList();
  }

 

  editClick(item){
    this.getClaims=item;
    this.ModalTitle="Edit Reimbursement Claim";
    this.ActivateAddEdit=true;
  }

 getPhase(item){
    this.getClaims=item;
    if(this.getClaims.ClaimPhase=="To Be Processed")
      return true;
    else
    return false;
  }

  addClaim(){
    var val={
      
    UserId: this.getClaims.UserId,
    ClaimType: this.getClaims.ClaimType,
    ClaimValue: this.getClaims.ClaimValue,
    Currency: this.getClaims.Currency,
    Date: this.getClaims.Date,
    ReceiptPhotoFileName: this.getClaims.ReceiptPhotoFileName,
    ClaimPhase: this.getClaims.ClaimPhase,
    isApproved: this.getClaims.isApproved,
    ApprovedBy: this.getClaims.ApprovedBy,
    ApprovedValue: this.getClaims.ApprovedValue,
    InternalNotes: this.getClaims.InternalNotes
    }

    this.userService.AddClaim(val).subscribe(res=>{
      alert(res.toString());
    });

    this.closeClick();
  }

  updateClaim(){
    var val={
     Id:this.getClaims.Id,
    UserId: this.getClaims.UserId,
    ClaimType: this.getClaims.ClaimType,
    ClaimValue: this.getClaims.ClaimValue,
    Currency: this.getClaims.Currency,
    Date: this.getClaims.Date,
    ReceiptPhotoFileName: this.getClaims.ReceiptPhotoFileName,
    ClaimPhase: this.getClaims.ClaimPhase,
    isApproved: this.getClaims.isApproved,
    ApprovedBy: this.getClaims.ApprovedBy,
    ApprovedValue: this.getClaims.ApprovedValue,
    InternalNotes: this.getClaims.InternalNotes
    }

    this.userService.UpdateClaim(val).subscribe(res=>{
      alert(res.toString());
    });

    this.closeClick();
  }

  deleteClick(item){
    this.getClaims=item;
    var val={
      
      UserId: this.getClaims.UserId,
      ClaimType: this.getClaims.ClaimType,
      ClaimValue: this.getClaims.ClaimValue,
      Currency: this.getClaims.Currency,
      Date: this.getClaims.Date,
      ReceiptPhotoFileName: this.getClaims.ReceiptPhotoFileName,
      ClaimPhase: this.getClaims.ClaimPhase,
      isApproved: this.getClaims.isApproved,
      ApprovedBy: this.getClaims.ApprovedBy,
      ApprovedValue: this.getClaims.ApprovedValue,
      InternalNotes: this.getClaims.InternalNotes
      }
  
    if(confirm('Are you sure?')){
    this.userService.DeleteClaim(val).subscribe(data=>{
      alert(data.toString());
      this.refreshClaimList();
    });
      
    }
  }

  uploadPhoto(event){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);
    this.userService.UploadPhoto(formData).subscribe((data:any)=>{
      this.getClaims.ReceiptPhotoFileName=data.toString();
      this.PhotoFilePath=this.userService.PhotoUrl+this.getClaims.ReceiptPhotoFileName;
    })
  }
}
