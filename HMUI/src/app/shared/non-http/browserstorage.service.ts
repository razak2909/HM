import { Injectable, DoCheck } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BrowserstorageService {

  public userDetails: any;
  public loggedInUser: any;
  public userRole: any;

  constructor() { }

}
