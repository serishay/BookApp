import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FavouriteService {

  private url="http://localhost:51409/api/";
  private recUrl="http://localhost:64371/api/Recommend"
  constructor(private http:HttpClient) { }

  getFavourite(userId:any){
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
     return this.http.get(this.url+"Favourite/"+userId,{headers : tokenHeader});
  }

  postFavourite(body){
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    return this.http.post(this.url+"Favourite/Add",body,{headers : tokenHeader})
  }

  deleteFavourite(userId,title){
    var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
    return this.http.delete(this.url+`Favourite/${userId}/${title}`,{headers : tokenHeader})
  }

  getRecommendation(){
    return this.http.get(this.recUrl);
  }
}
