import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { title } from 'process';
import { Favourite } from 'src/app/models/fav';
import { SearchResult } from 'src/app/models/search-result';
import { FavouriteService } from 'src/app/Services/favourite.service';
import { SearchService } from 'src/app/Services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

export class SearchComponent implements OnInit {

  constructor(private builder:FormBuilder,private router:Router, public service:SearchService,public favService:FavouriteService) { }

  searchList=this.builder.group({
    category:['']
  });

  items: Array<any>;
  gridColumns=4;
  fav:Favourite;
  submitted=false;
  ngOnInit(): void {
  }

  onSubmit(){
  this.service.getSearchList(this.searchList.value).subscribe(
  data=>{
    this.items=data['items'];
    console.log(this.items);
  },
  err=>{
    alert("Enter category to search");
    console.log(err);
    });
  }

  onFav(items){
    if(localStorage.getItem('token')==null){
       this.router.navigate(['/users/login']);
       alert("Please Login first");
     }
    else{
      this.fav=new Favourite();
      localStorage.setItem('title',items.volumeInfo.title);
      localStorage.setItem('author',items.volumeInfo.authors)
      localStorage.setItem('urlImg',items.volumeInfo.imageLinks.thumbnail);
      localStorage.setItem('webUrl',items.accessInfo.webReaderLink);
      var bookTitle=localStorage.getItem('title');
      var bookImgUrl=localStorage.getItem('urlImg');
      var bookReading=localStorage.getItem('webUrl');
      var bookAuthor=localStorage.getItem('author');
      this.fav.title=bookTitle;
      this.fav.urlImg=bookImgUrl;
      this.fav.webUrl=bookReading;
      this.fav.author=bookAuthor;
      this.fav.userId=localStorage.getItem('currentUser');
      console.log(this.fav);
      this.favService.postFavourite(this.fav).subscribe(
        data=>{
          console.log(data);
          alert("Added to favourite list successfully");
        },
        err=>{
          alert("Already exists in favourite list");
        }
    );
  }
}
}