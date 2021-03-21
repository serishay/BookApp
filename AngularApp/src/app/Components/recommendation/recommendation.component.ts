import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Favourite } from 'src/app/models/fav';
import { FavouriteService } from 'src/app/Services/favourite.service';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.css']
})
export class RecommendationComponent implements OnInit {
recommend:string[]=[];
fav:Favourite;
  constructor(private recService:FavouriteService,private router:Router) { }

  ngOnInit(): void {
    this.recService.getRecommendation().subscribe(
      data=>{
          console.log(data);
          this.recommend=data as string[];
    });
  }

  onFavourite(item){
    this.fav=new Favourite();
    localStorage.setItem('title',item.title);
    localStorage.setItem('author',item.author)
    localStorage.setItem('urlImg',item.urlImg);
    localStorage.setItem('webUrl',item.webUrl);
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
    this.recService.postFavourite(this.fav).subscribe(
      data=>{
        alert("Added to Favourite")
      },
      err=>{
        alert("Already favourite");
      }
  );
}
}
