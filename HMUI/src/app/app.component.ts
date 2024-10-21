import { Component } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'PETC-Admin';
  public accessToken: any = sessionStorage.getItem('accessToken');
  public _path: any;

  constructor(
    public location: Location,
  ) { }

  ngOnInit() {
    this._path = this.location.path().split('/')[1];
    this.accessToken = sessionStorage.getItem('accessToken');
  }

  ngDoCheck() {
    this.accessToken = sessionStorage.getItem('accessToken');
  }

  onActivate(event: any, srElement: any) {
    srElement.scrollIntoView({ behavior: "smooth", block: "start", inline: "nearest" });
  }
}
