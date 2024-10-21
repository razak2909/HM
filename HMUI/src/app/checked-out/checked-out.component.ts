import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import * as element from 'lodash';
import { BrowserstorageService } from '../shared/non-http/browserstorage.service';

import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-checked-out',
  templateUrl: './checked-out.component.html',
  styleUrls: ['./checked-out.component.scss'],
})
export class CheckedOutComponent implements OnInit {
  DepartmentList: any;
  router: any;
  TotalStayCost: any;
  guestDetails:any;
  guest: any;
  selectedGuest: any;
  selectedPhotoFileName: any;
  selectedPhotoFile: any;
    photodelete!: boolean;
  filteredRooms: any;
    imagePreview!: string | ArrayBuffer | null;
  selectedPhotoFileUrl: any;
  formSubmit: boolean = false;
  formEdit: boolean = false;
  modalRef: BsModalRef | null = null;
  dtOptions: any; // Define as any to allow flexible options
  createUserForm!: FormGroup;


  onAddUserModal(arg0: any) {
    throw new Error('Method not implemented.');
  }
  export(arg0: string) {
    throw new Error('Method not implemented.');
  }

  constructor(
    private ngxService: NgxUiLoaderService,
    private toster: ToastrService,
    private commonservice: CommonserviceService,
    public modalService: BsModalService,
    public browserStorageService: BrowserstorageService,
    public date: DatePipe,
  ) {}

  ngOnInit(): void {
    this.onGetAllUser();
    // this.TotalCost();
  }

  onGetAllUser() {
    let url = `api/BookingList/getCheckedOutList`;
    this.ngxService.start();
    this.commonservice.getBookedList(url).subscribe(
      (data: any) => {
        if (data['Success'] == true) {
          this.DepartmentList = data.Data;
          setTimeout(() => {
            this.ngxService.stop();
          }, 150);
        } else {
          this.toster.error('error Getting Data');
          this.ngxService.stop();
        }
      },
      (error) => {
        this.ngxService.stop();
      }
    );
  }

  onViewGuestModal(template :TemplateRef<any>,guestId:any){
    this.formEdit = false;
    this.formSubmit = false;
    this.createUserForm.reset();
    this.onGuestById(guestId); 
  
    this.modalRef = this.modalService.show(template,
      {
          class : 'modal-lg modal-dialog modal-dialog-centered' ,
          backdrop: 'static',
          keyboard: false
    })
  }

  onGuestById(guestId:any) {
  let URL = `api/Guests?id=${guestId}`;
  this.ngxService.start();
  this.commonservice.onconnonGet(URL)
    .subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.guestDetails =  res['Data'];
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
  

  TotalCost() {
    this.TotalStayCost = this.DepartmentList.RoomPricePerDay;
    console.log('val', this.TotalStayCost);
  }

  
onPhotoFileUpload(event: any) {
  //   console.log("Upload button clicked");
  const file = event.target.files[0];
  this.photodelete = true;

  if (file instanceof File) {
    this.selectedPhotoFile = file;
    this.selectedPhotoFileName = file.name;

    var _URL = window.URL; //window.webkitURL;
    var objectUrl = _URL.createObjectURL(file);
    // file["url"] = objectUrl;
    this.selectedPhotoFileUrl = _URL.createObjectURL(file);
  }
}

triggerPhotoFileInput() {
  const fileInput = document.getElementById('Photo-File');
  if (fileInput) {
    fileInput.click();
  }
}

deletePhotoFile(PhotoFileInput: string) {
  this.photodelete = true;

  this.selectedPhotoFile = null;
  // this.createUserForm.value.PhotoFileName = "";
  $(`#${PhotoFileInput}`).val('');
}

photomodel(template: TemplateRef<any>) {
  this.modalRef = this.modalService.show(template, {
    class: 'modal-lg modal-dialog modal-dialog-centered',
    backdrop: 'static',
    keyboard: false,
  });
}
}
