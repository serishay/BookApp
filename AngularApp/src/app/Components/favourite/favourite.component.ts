import { Component, OnInit } from '@angular/core';
import { Favourite } from 'src/app/models/fav';
import { FavouriteService } from 'src/app/Services/favourite.service';

@Component({
  selector: 'app-favourite',
  templateUrl: './favourite.component.html',
  styleUrls: ['./favourite.component.css']
})
export class FavouriteComponent implements OnInit {

  favourite:string[];
  items:Array<any>
  constructor(private favService:FavouriteService) { }

  ngOnInit(): void {
    var userId=localStorage.getItem('currentUser');
    this.favService.getFavourite(userId).subscribe(
      list=>{
        console.log(list);
        this.favourite=list as string[];
        console.log(this.favourite);
      },
      err=>{
    alert("No favourites :(")
      }
    )
  }
  delete(item){
    var title=item.title;
    var userId=localStorage.getItem('currentUser');
    this.favService.deleteFavourite(userId,title).subscribe(
      data=>{
        console.log(data);
        this.ngOnInit();
      }
    )

  }  
}
