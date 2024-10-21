import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import * as element from 'lodash';
import { BrowserstorageService } from '../shared/non-http/browserstorage.service';

import { DatePipe } from '@angular/common';



import * as ExcelJS from 'exceljs';
import * as fs from 'file-saver';
import { cwd } from 'process';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { MatSelectChange } from '@angular/material/select';
declare var require: any;
var jsPDF = require('jspdf');

@Component({
  selector: 'app-checked-in',
  templateUrl: './checked-in.component.html',
  styleUrls: ['./checked-in.component.scss']
})
export class CheckedInComponent implements OnInit {

filteredRoomtypes: any;

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
  DepartmentList: any;
  createUserForm!: FormGroup;

  constructor(
    private ngxService: NgxUiLoaderService,
    private toster: ToastrService,
    private commonservice: CommonserviceService,
    public modalService: BsModalService,
    public browserStorageService: BrowserstorageService,
    public date: DatePipe,
    public router: Router
  ) {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      scrollX: false,
      processing: true,
      "order": [],
      "columnDefs": [{ "orderable": false, "targets": "_all" }]
    };
  }

  ngOnInit(): void {
    this.onGetAllUser();

    this.createUserForm = new FormGroup({
      GuestName: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z ]*$'),
      ]), // Allow spaces for names
      ContactNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]{10}$'),
      ]), // Only digits, no space
      IDProof: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z ]*$'),
      ]), // Allow spaces for multi-word types
   
      RoomNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9A-Z]*$'),
      ]), // Allow numbers and uppercase letters
      RoomType: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z ]*$'),
      ]), // Room type should allow alphabets and spaces

      IDProofNumber: new FormControl('',[
        Validators.required,
        Validators.pattern('^[0-9]*$'),
      ]),
      //   CFOOrderDate : new FormControl()
      RoomId: new FormControl('', [Validators.required]),
      RoomTypeId: new FormControl('', [Validators.required]),
    });

    

  }



  onGetAllUser() {
    let url = `api/BookingList/getCheckInList`;
    this.ngxService.start();
    this.commonservice.getBookedList(url)
      .subscribe(
        (data: any) => {
          if (data['Success'] === true) {
            this.DepartmentList = data.Data;
            this.ngxService.stop();
          } else {
            this.toster.error('Error Getting Data');
            this.ngxService.stop();
          }
        },
        (error) => {
          this.ngxService.stop();
          this.toster.error('Error retrieving data');
        }
      );
  }

  onAddGuestModal(template: TemplateRef<any>) {
    this.formEdit = false;
    this.formSubmit = false;
    this.createUserForm.reset();
    this.onGetAllRoomType();
    this.onGetAllRooms();


    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false
    });
  }

  onGetAllRooms() {
    let URL = `api/Rooms`;
    this.ngxService.start();
    this.commonservice.onconnonGet(URL).subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.filteredRooms = res['Data'];
          // console.log('test: ',this.filteredRooms)
        } else {
          this.toster.error('Error getting data.');
        }
        this.ngxService.stop();
      },
      (error: any) => {
        this.ngxService.stop();
      }
    );
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

  onCheckOut(roomId:any,bookingId:any) {
    console.log("val",roomId , "val1" , bookingId)
    let URL = `api/BookingList/updateBookingCheckOut?roomid=${roomId}&bookingId=${bookingId}`;
    this.ngxService.start();
    this.commonservice.onconnonGet(URL).subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.toster.success('CheckedOut Successfully.')
          this.router.navigate(['/checkedout']);
        } else {
          this.toster.error('Error getting data.');
        }
        this.ngxService.stop();
      },
      (error: any) => {
        this.ngxService.stop();
      }
    );
  }

  onAddGuestSubmit() {
    if (this.createUserForm.valid) {
      const url = 'api/BookingList/addGuest'; // Update with your actual API endpoint
      this.ngxService.start();
      this.commonservice['postData'](url, this.createUserForm.value).subscribe(
        (data: any) => {
          if (data['Success'] === true) {
            this.toster.success('Guest added successfully!');
            this.onGetAllUser(); // Refresh the list
            this.modalRef?.hide(); // Close the modal
          } else {
            this.toster.error('Error adding guest');
          }
          this.ngxService.stop();
        },
        (error : any) => {
          this.toster.error('Error adding guest');
          this.ngxService.stop();
        }
      );
    } else {
      this.toster.error('Please fill all required fields correctly.');
    }
  }

  // Method to handle file selection and preview
 

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


