import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(
    private httpClient: HttpClient ,
    private loadservice : NgxUiLoaderService,
    private toster : ToastrService,
    ) {}

  onLogin(credentialObj: any) {
    const body = new HttpParams()
      .set('UserName', credentialObj.UserName)
      .set('Password', credentialObj.Password)
      // .set('Role', credentialObj.Role)
      .set('grant_type', 'password');
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urlencoded',
      }),
    };
    return this.httpClient.post(
      `${environment.baseUrl}login`,
      body,
      httpOptions
    );
  }

  onRefreshLogin(refreshToken: string) {
    const body = new HttpParams()
      .set('refresh_token', refreshToken)
      .set('grant_type', 'refresh_token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/x-www-form-urlencoded',
      }),
    };
    return this.httpClient.post(
      `${environment.baseUrl}login`,
      body,
      httpOptions
    );
  }

  ChangePassword(profileObj: any) {
    return this.httpClient.post(
      `${environment.baseUrl}api/User/changepassword`,
      profileObj
    );
  }

  ForgotPassword(param: any) {
    return this.httpClient.put(
      `${environment.baseUrl}api/User/forgotpassword`,
      param
    );
  }

  ResetPassword(param: any) {
    return this.httpClient.put(
      `${environment.baseUrl}api/User/resetpassword`,
      param
    );
  }

  onlogOut(){
    sessionStorage.removeItem('refresToken');
    sessionStorage.removeItem('accessToken')
    this.loadservice.start();
    this.toster.success("Logout");
    sessionStorage.clear();
    this.loadservice.stop();

    setTimeout(()=>{
      this.loadservice.stop();
      window.location.href = '/login';
    },1000);
  }
}
