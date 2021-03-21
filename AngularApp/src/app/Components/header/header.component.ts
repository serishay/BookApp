import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SearchService } from 'src/app/Services/search.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private builder:FormBuilder,private router:Router, public service:SearchService) { }

  ngOnInit(): void{}

  logedIn(){
    return localStorage.getItem('token');
    

  }
  onLogout(){
    localStorage.removeItem('token');
    alert("Logged out successfully!!!")
    this.router.navigate(['/users/login']);
  }
}
