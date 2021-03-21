import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

user:User;
  constructor(public service:UserService,private router:Router) {}
  

  ngOnInit(): void {
    this.service.registerForm.reset();
  }

  onSubmit(){
    this.user=new User();
    this.user.userId=this.service.registerForm.get('UserId').value;
    this.user.password=this.service.registerForm.get('Passwords.Password').value;
    console.log(this.user);
    this.service.register().subscribe(
      data=>{
        alert("Registered successfully");
        console.log(data);
        this.service.registerForm.reset();
        this.router.navigate(['/users/login']);
      },
      err=>{
        alert("Registration failed")
      }
    );
  }
}
