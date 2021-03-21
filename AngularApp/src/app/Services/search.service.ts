import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  public apiKey="AIzaSyAQyatJfCm_mQN4wp26ZNySA5Yq69PC73w";

  constructor(private http:HttpClient, private builder:FormBuilder) { }


  getSearchList(searchData){
      return this.http.get(`https://www.googleapis.com/books/v1/volumes?q=${searchData.category}&maxResults=12&key=${this.apiKey}`);
     //return this.http.get("http://openlibrary.org/search?json/author="+searchData);
    }
  }

