import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DataTablesModule } from 'angular-datatables';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { AuthenticationInterceptor } from './shared/http/auth.interceptor';
import { DatePipe } from '@angular/common';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './department/department.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { HeadderComponent } from './headder/headder.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { CheckedInComponent } from './checked-in/checked-in.component';
import { CheckedOutComponent } from './checked-out/checked-out.component';
import { RoomsComponent } from './MasterTable/rooms/rooms.component';
import { RoleComponent } from './MasterTable/role/role.component';
import { RoomTypeComponent } from './MasterTable/room-type/room-type.component';
import { ViewdetailsComponent } from './department/viewdetails/viewdetails.component';
import { Viewdetails1Component } from './checked-in/viewdetails1/viewdetails1.component';
import { Viewdetails2Component } from './checked-out/viewdetails2/viewdetails2.component';






@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    DashboardComponent,
    HeadderComponent,
    LoginComponent,
    UserComponent,
    CheckedInComponent,
    CheckedOutComponent,
    RoomsComponent,
    RoleComponent,
    RoomTypeComponent,
    ViewdetailsComponent,
    Viewdetails1Component,
    Viewdetails2Component,
  
   
   
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxUiLoaderModule,
    ModalModule.forRoot(),
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    DataTablesModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatInputModule,
    NgxMaterialTimepickerModule,
   
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
    DatePipe,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
