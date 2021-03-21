import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LogIn } from 'src/app/models/logIn';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formModel={
    UserId:'',
    Password:''
  }

  loginUser:LogIn;
  constructor(private service:UserService,private router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.loginUser=new LogIn();
    this.loginUser.userId=this.formModel.UserId.valueOf();
    this.loginUser.password=this.formModel.Password.valueOf();
    localStorage.setItem('currentUser',this.loginUser.userId);
    this.service.login(this.loginUser).subscribe(
      (res:any)=>{
        localStorage.setItem('token', res.token);
        this.router.navigate(['/favourite']);
      },
      err=>{
        if(err.status==400){
          alert("Invalid user or password");
        }
        else
          alert("Unauthorized User");
      }
    )
  }
}
