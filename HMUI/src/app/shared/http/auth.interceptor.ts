import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginService } from './login.service';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  constructor(
    private loginService: LoginService,
    private toastr: ToastrService,
    private showLoaderService: NgxUiLoaderService,
  ) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('accessToken');
    let cloned = req;
    if (token && !req.url.includes('account/token') && !location.pathname.includes('/profile')) {
      cloned = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + token)
      });
    }
    return next.handle(cloned).pipe(catchError((err: any) => {
      if([401].includes(err.status)){
        
        this.toastr.error("You are not allowed to access to this page")
        this.showLoaderService.start()
        setTimeout(()=>{
          window.location.href = '/dashboard'
          this.showLoaderService.stop()
        },1500);

      }
      if ([403].includes(err.status)) {
        sessionStorage.removeItem('accessToken');
        this.toastr.error("Refreshing...", "Session expired!!!", {
          closeButton: true,
          positionClass: 'toast-top-right',
          timeOut: 2000,
          easeTime: 800,
        });
        // sessionStorage.clear();
        if (sessionStorage.getItem('refresToken') != null) {
          const refresToken = sessionStorage.getItem('refresToken') ?? "";
          this.onRefreshToken(refresToken);
        } else { 
          window.location.href = '/login';
        }
        return throwError(err);
      }
      else if ([400, 404, 409, 500, 501].includes(err.status)) {
        return throwError(err);
      }
      return throwError(err);
      this.showLoaderService.stop();
    }));
  }

  onRefreshToken(refresToken: string) {
    sessionStorage.removeItem('refresToken');
    this.showLoaderService.start();
    this.loginService.onRefreshLogin(refresToken).subscribe((res: any) => {
      this.toastr.success("Sesson refreshed successfully.", "Session active!!!", {
        closeButton: true,
        positionClass: 'toast-top-right',
        timeOut: 5000,
        easeTime: 2000,
      });
      setTimeout(() => {
        window.location.href = '/login';
        this.showLoaderService.stop();
      }, 2000);
      sessionStorage.setItem('accessToken', res['access_token']);
      sessionStorage.setItem('refresToken', res['refresh_token']);
    },
      (error) => {
        this.toastr.error("Signing out...", "Refresh token expired!!!", {
          closeButton: true,
          positionClass: 'toast-top-right',
          timeOut: 6000,
          easeTime: 500,
        });
        sessionStorage.clear();
        this.showLoaderService.stop();
        setTimeout(() => {
          window.location.href = '/login';
          this.showLoaderService.stop();
        }, 1000);
      });
  }
}
