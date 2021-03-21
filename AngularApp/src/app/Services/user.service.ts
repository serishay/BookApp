import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { RegistrationComponent } from '../Components/users/registration/registration.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class UserService {
 readonly BaseUrl='http://localhost:50192/api/';
  constructor(private builder:FormBuilder,private http:HttpClient) { }
  
  registerForm=this.builder.group({
    UserId:['',Validators.required],
    Passwords:this.builder.group({
      Password:['',[Validators.required,Validators.minLength(4)]],
      ConfirmPassword:['',[Validators.required]]
    },{validator: this.comparePasswords})
  });

  comparePasswords(builder:FormGroup){
    let confirmPasswordControl=builder.get('ConfirmPassword');
    if(confirmPasswordControl.errors ==null || 'passwordMismatch' in confirmPasswordControl.errors){
    if(builder.get('Password').value != confirmPasswordControl.value)
      confirmPasswordControl.setErrors({passwordMismatch:true});
    else
       confirmPasswordControl.setErrors(null);
    }
    }
    register(){
      var body={
        UserId : this.registerForm.value.UserId,
        Password :this .registerForm.value.Passwords.Password
      }
      return this.http.post(this.BaseUrl+'Auth/register',body);
    }

    login(formData){
      return this.http.post(this.BaseUrl+'Auth/login',formData);
    }
  }
