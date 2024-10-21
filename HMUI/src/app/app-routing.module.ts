import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RouterprotectionguardService } from './shared/non-http/routerprotectionguard.service';
import { DepartmentComponent } from './department/department.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeadderComponent } from './headder/headder.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { CheckedInComponent } from './checked-in/checked-in.component';
import { CheckedOutComponent } from './checked-out/checked-out.component';
import { RoomTypeComponent } from './MasterTable/room-type/room-type.component';
import { RoomsComponent } from './MasterTable/rooms/rooms.component';
import { RoleComponent } from './MasterTable/role/role.component';
import { ViewdetailsComponent } from './department/viewdetails/viewdetails.component';
import { Viewdetails1Component } from './checked-in/viewdetails1/viewdetails1.component';
import { Viewdetails2Component } from './checked-out/viewdetails2/viewdetails2.component';


const routes: Routes = [
  {path : 'login' , component : LoginComponent} ,
  {path :'headders' , component : HeadderComponent},
  {path :'dashboard', component :DashboardComponent},
  {path : 'booked' , component :DepartmentComponent},

  {path :'user',component : UserComponent},
  {path : 'checkedin' , component :CheckedInComponent},


  {path : 'Viewdetails2/:guestId' , component : Viewdetails2Component},
  {path : 'Viewdetails1/:guestId' , component : Viewdetails1Component},
  {path : 'Viewdetails/:guestId' , component :ViewdetailsComponent},
  
  {path : 'checkedout' , component :CheckedOutComponent},
  {path : 'room' , component :RoomsComponent},
  {path : 'roomtype' , component :RoomTypeComponent},
  {path : 'role' , component :RoleComponent},


  

  { path: '**', redirectTo: 'login', pathMatch: 'full' },
 

]; 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
