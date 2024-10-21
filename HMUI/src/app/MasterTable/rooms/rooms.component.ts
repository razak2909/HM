import { Component, OnInit , TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { FormControl,FormGroup} from '@angular/forms';
import { BsModalRef,BsModalService } from 'ngx-bootstrap/modal';
import * as element from 'lodash';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.scss']
})
export class RoomsComponent implements OnInit {
  selectedRoomTypeID: any;
  DepartmentList: any;
  router: any;

  createRoomsForm : any = FormGroup;
  modalRef : BsModalRef | null = null;

  filteredRooms : any;

  IsEdit :boolean = false;
  formSubmitted : any;

export(arg0: string) {
throw new Error('Method not implemented.');
}
onAddUserModal(arg0: any) {
throw new Error('Method not implemented.');
}


  constructor(
    private ngxService : NgxUiLoaderService,
    private toster : ToastrService,
    private commonservice : CommonserviceService,
    public modalService : BsModalService
  ) { }

  ngOnInit(): void {
    this.onGetAllRooms();

    this.createRoomsForm = new FormGroup({
      RoomNumber : new FormControl(),
      RoomTypeId : new FormControl(),
      roomStatus : new FormControl()
    })

  }

  onGetAllRooms(){
    let url = `api/Rooms`
    this.ngxService.start();
    this.commonservice. getBookedList(url)
    .subscribe(
      (data : any)=>{
        if(data['Success'] == true){
          this.DepartmentList = data.Data;

          setTimeout(() =>{
            this.ngxService.stop();
          }, 150);
        }else{
          this.toster.error('error Getting Data');
          this.ngxService.stop();
        }
      },
      (error) =>{
        this.ngxService.stop();
      }
    );
  }

  onAddRoomsModel(){
    let formObj = this.createRoomsForm.value;
    const formData = new FormData();

    formData.append('JsonObjStr', JSON.stringify(formObj));

    if(this.IsEdit){
      let URL = `api/Rooms?id=${this.selectedRoomTypeID}`;
    this.ngxService.start();
    this.commonservice.updatePut(URL, formObj).subscribe(
      (res: any) => {
        this.ngxService.stop();
        if (res['Success']) {
          this.createRoomsForm.reset();
          this.toster.success('Request completed successfully!');
          this.onGetAllRooms();

        } else {
          this.toster.error("Error :"+res['ErrorMessage']);
        }
        this.modalService.hide();
        this.IsEdit = false;
      },
      (error : any) => {
        this.ngxService.stop();
      }
    );
    }

    else{
    let URL = `api/Rooms`;
    this.ngxService.start();
    this.commonservice.addPost(URL, formObj).subscribe(
      (res: any) => {
        this.ngxService.stop();
        if (res['Success']) {
          this.createRoomsForm.reset();
          this.toster.success('Request completed successfully!');
          this.onGetAllRooms();
        } else {
          this.toster.error("Error :"+res['ErrorMessage']);
        }
        this.modalService.hide();
        //this.IsEdit = false;
      },
      (error : any) => {
        this.ngxService.stop();
      }
    );
  }
  }

  onAddRooms(template: TemplateRef<any>){
    this.createRoomsForm.reset();
    this.onGetAllRoomType();
    this.IsEdit = false;
    this.modalRef = this.modalService.show(template,
      {
        class: 'modal-md modal-dialog modal-dialog-centered',
        backdrop: 'static',
        keyboard: false
       });
    }

onGetAllRoomType() {
  let URL = `api/RoomTypes`;
  this.ngxService.start();
  this.commonservice.onconnonGet(URL)
    .subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.filteredRooms =  res['Data'];
          console.log('test: ',this.filteredRooms)
        } else {
          this.toster.error('Error getting data.');
        }
        this.ngxService.stop();
      },
      (error : any) => {
        this.ngxService.stop();
      }
        );
    }


onEditRooms(template: TemplateRef<any>, dataObject: any) {
  this.IsEdit = true;
  this.formSubmitted = false;
  this.createRoomsForm.reset();
  this.selectedRoomTypeID = dataObject.RoomId

  this.onGetAllRoomType();

  this.createRoomsForm.setValue(
    element.pick(dataObject,
      [
      'RoomNumber',
      'RoomTypeId',
      'roomStatus'
    ])
  );
 
  this.modalRef = this.modalService.show(template,
    {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false
      });
  }
  

onDeleteRooms(template: TemplateRef<any>, dataObject: any) {
  this.formSubmitted = false;
  this.createRoomsForm.reset(); // Reset the form

  console.log(dataObject)
  this.selectedRoomTypeID = dataObject; // Set RoomId for reference
  
  // Show a confirmation modal
  this.modalRef = this.modalService.show(template, {
    class: 'modal-lg modal-dialog modal-dialog-centered',
    backdrop: 'static',
    keyboard: false
  });
}

// This method will be called when the user confirms deletion
confirmDelete() {

  console.log("val",this.selectedRoomTypeID)
  // Call the service to delete the room by RoomId
  let url = `api/Rooms?id=${this.selectedRoomTypeID}`;
  this.commonservice.deleteR(url).subscribe(
    (response: any) => {
      console.log("Room deleted successfully!", response);
      this.modalRef?.hide(); // Safely close modal if it exists
      this.onGetAllRooms(); // Refresh the list of rooms
    },
    (error: any) => {
      console.error("Error deleting room", error);
      // Optionally, show an error message to the user
    }
  );
}


  

}
