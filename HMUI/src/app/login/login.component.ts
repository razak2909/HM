import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../shared/http/login.service';
import { CommonserviceService } from '../shared/http/commonservice.service';
import { AbstractControl } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm!: FormGroup;
  public ForgotForm!: FormGroup;
  public IsPopUp = false;

  public fetchedUser : any;
  public fetchedUserRole : any;


  isShowPass = false;
  hide = true;
  User: any;

  constructor(
    private router: Router,
    private showLoaderService: NgxUiLoaderService,
    private loginService: LoginService,
    private toastr: ToastrService,
    private commonService: CommonserviceService,
  ) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      UserName: new FormControl(null, [Validators.required, Validators.pattern('^[a-zA-Z0-9 ]*$')]),
      Password: new FormControl(null, Validators.required),
      Role: new FormControl('superadmin')
    });
    this.ForgotForm = new FormGroup({
      UserId: new FormControl(null, [Validators.required, Validators.pattern('^[a-zA-Z0-9]*$')]),
      EmailId: new FormControl(null, [Validators.required]),
      Password : new FormControl(null,[Validators.required]),
      ConfirmPassword : new FormControl(null,[Validators.required])
    });
    if (sessionStorage.getItem('accessToken') != null) {
      this.router.navigate(['dashboard']);
    }

    const togglePassword: any = document.querySelector('#togglePassword');
    const password: any = document.querySelector('#id_password');

    togglePassword.addEventListener('click', function (e: any) {
      // toggle the type attribute
      const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
      password.setAttribute('type', type);
      // toggle the eye slash icon
      e.classList.toggle('fa-eye-slash');
    });

  }

  
  onLogin() {
    var param = {
      UserName: this.loginForm.controls['UserName'].value,
      Password: this.loginForm.controls['Password'].value
    }
    this.showLoaderService.start();
    this.loginService.onLogin(param)
      .subscribe(
        (res: any) => {
          if (res) {
            this.showLoaderService.stop();
            sessionStorage.setItem('userDetails', JSON.stringify(res));
            sessionStorage.setItem('loggedInUser', this.loginForm.controls['UserName'].value);
            sessionStorage.setItem('accessToken', res['access_token']);
            sessionStorage.setItem('refreshToken', res['refresh_token']);
            
            this.onGetUserById(this.loginForm.controls['UserName'].value);

            setTimeout(() => {
              //window.location.href = "/dashboard";
              this.router.navigate(['/dashboard']);
            }, 100);
          }
        },
        error => {
          console.log(error);
          this.showLoaderService.stop();
          this.toastr.error('Invalid Credentials!');
        }
      );
  }

  onGetUserById(UserId: any) {
    let URL = `api/User?key=${UserId}`;
    this.showLoaderService.start();
    this.commonService.onconnonGet(URL)
      .subscribe(
        (res: any) => {
          if (res) {
            this.fetchedUser = res;
            this.fetchedUserRole = res.UserRoleName;
            // console.log("UserRoleName: ",res.UserRoleName,'Rolename : ',res['Data'].RoleName)
            sessionStorage.setItem('userRole', res['Data'].RoleName);
            // sessionStorage.setItem('userDesignation', res['Data'].UserDesignation);
          } else {
            this.toastr.error('Error getting data.');
          }
          this.showLoaderService.stop();
        },
        (error) => {
          this.showLoaderService.stop();
        }
      );
  }

  OpenModel() {
    this.IsPopUp = true;
  }

  closeModel() {
    this.IsPopUp = false;
    this.ForgotForm.reset();
  }

  Submit() {
    var param = {
      UserName: this.loginForm.controls['UserName'].value,
      Email: this.loginForm.controls['Email'].value,
      
    }
    this.showLoaderService.start();
    this.loginService.ForgotPassword(param)
      .subscribe(
        (res: any) => {
          this.showLoaderService.stop();
          if (res['success'] === true) {
            this.closeModel();
            console.log(res['data'])
            this.toastr.success(res['message']);
          } else {
            this.toastr.error(res['message']);
          }
        },
        error => {
          console.log(error);
          this.showLoaderService.stop();
          this.toastr.error(error.error.Data.Message);
        }
      );
  }

  ForgotSubmit() {
    var param = {
      UserId: this.ForgotForm.controls['UserId'].value,
      EmailId: this.ForgotForm.controls['EmailId'].value,
      Password : this.ForgotForm.controls['Password'].value
    }

    let formObj = this.ForgotForm.value;
    const formData = new FormData();
    formData.append('JsonObjStr', JSON.stringify(formObj));  
    console.log(formObj)

    this.showLoaderService.start();
    this.loginService.ForgotPassword(param)
      .subscribe(
        (res: any) => {
          this.showLoaderService.stop();
          if (res['Success'] == true) {
            this.closeModel();
            console.log(res['data'])
            this.toastr.success(res['Data']);
          } else {
           this.closeModel();
            this.toastr.error(res['Data']);
          }
        },
        error => {
          console.log(error);
          this.showLoaderService.stop();
          this.toastr.error(error.error.Data.Message);
        }
      );
  }

  onPaste(event: ClipboardEvent) {
    setTimeout(() => {
      const passwordControl = this.loginForm.get('Password');
      if (passwordControl) {
        passwordControl.reset();
      }
    }, 10);
  }


}
