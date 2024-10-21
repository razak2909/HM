import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { DatePipe } from '@angular/common';
import { data } from 'jquery';

@Injectable({
  providedIn: 'root'
})
export class CommonserviceService {
  [x: string]: any;

  constructor(private http: HttpClient, private datePipe: DatePipe) { }

  onconnonGet(url : any){
    return this.http.get(environment.baseUrl+url)
  }

  getBookedList(url : any ){
    return this.http.get(environment.baseUrl+url)
  }

  addPost(url : any, data : any){
    return this.http.post(environment.baseUrl + url , data)
  }

  updatePut(url : any,data : any){
    return this.http.put(environment.baseUrl+ url ,data)
  }


  Delete(url : any,data : any){
    return this.http.delete(environment.baseUrl+url , data)
  }

  /////////////////////////////////////////////////////////////////////////////

  Date(){
    return this.datePipe.transform(new Date(),"dd-MM-yyyy");
  }

/////////////////////////////////////////////////////////////////////





getTotalBookingCount(url : any){
  return this.http.get(environment.baseUrl+url)
}

  getUserList(url : any){
    return this.http.get(environment.baseUrl+url)
  }

  getTotalEmployeeCount(url : any){
    return this.http.get(environment.baseUrl+url)
  }

  addUser(data: any,url : any){
    return this.http.post(environment.baseUrl+url,data)
  }

  // updateUser(url : any , data : any , id : any){
  //   return this.http.put(environment.baseUrl+url+id,data)
  // }

  deleteR(url : any ){
    return this.http.delete(environment.baseUrl+url)
  }

}


