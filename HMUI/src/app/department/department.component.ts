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
declare var require: any;
var jsPDF = require('jspdf');

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss'],
})
export class DepartmentComponent implements OnInit {
  guestDetails: any;
  guest: any;
  selectedGuest: any;
  selectedPhotoFileUrl: any;
  selectedPhotoFileName: any;
  selectedPhotoFile: any;
  photodelete!: boolean;
  item: any;

  RoomTypeId : any;

  onViewGuestDetails(arg0: any) {
    throw new Error('Method not implemented.');
  }
  imagePreview!: string | ArrayBuffer | null;
  filteredRooms: any;
  filteredRoomtypes: any;

  // guestPhoto: any;
  onFileChange($event: Event) {
    throw new Error('Method not implemented.');
  }


  BookedList: any;
  createUserForm: any = FormGroup;
  id: any;

  SelectedUser: any;
  formSubmit: boolean = false;
  formEdit: boolean = false;
  modalRef: BsModalRef | null = null;
  fileName!: string;
  alluser: any;
  dtOptions: DataTables.Settings = {};
  // router: any;
  DepartmentList: any;

  constructor(
    private commonservice: CommonserviceService,
    private ngxService: NgxUiLoaderService,
    private toster: ToastrService,
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
      order: [], // sorting 2nd column
      columnDefs: [
        { orderable: false, targets: '_all' }, // Applies the option to all columns
      ],
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
      Email : new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$'),
      ]),
      IdProofType: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z ]*$'),
      ]), // Allow spaces for multi-word types
   
      RoomId: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9A-Z]*$'),
      ]), // Allow numbers and uppercase letters
      RoomType: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z ]*$'),
      ]), // Room type should allow alphabets and spaces

      IdProofNumber: new FormControl('',[
        Validators.required,
        Validators.pattern('^[0-9]*$'),
      ]),
      //   CFOOrderDate : new FormControl()

      TotalDays: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]+$'), // Example pattern for numeric values
      ]),
      NumberOfGuests: new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9]+$'), // Example pattern for numeric values
      ]),
      IDProofPhoto : new FormControl('', [
        Validators.required,
        Validators.pattern('^[0-9A-Za-z]*$'),
      ]),

    });

    

  }

  onGetAllUser() {
    let url = `api/BookingList/getBookedList`;
    this.ngxService.start();
    this.commonservice.getBookedList(url).subscribe(
      (data: any) => {
        if (data['Success'] == true) {
          this.BookedList = data.Data;
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



  onAddGuestModal(template: TemplateRef<any>) {
    this.formEdit = false;
    this.formSubmit = false;
    this.createUserForm.reset();
    this.onGetAllRoomType();
    this.onGetAllRooms();

    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false,
    });
  }

  onViewGuestModal(template: TemplateRef<any>, guestId: any) {
    this.formEdit = false;
    this.formSubmit = false;
    this.createUserForm.reset();
    this.onGuestById(guestId);

    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false,
    });
  }

  onGetAllRoomType() {
    let URL = `api/RoomTypes`;
    this.ngxService.start();
    this.commonservice.onconnonGet(URL).subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.filteredRoomtypes = res['Data'];

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

  onGetAllCheckOutRoomsNumber(event:any) {
    const RoomTypeId =event?.value || -1;
    let URL = `api/EmptyRoomNumber?RoomTypeId=${RoomTypeId}`;
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

  onGuestById(guestId: any) {
    let URL = `api/Guests?id=${guestId}`;
    this.ngxService.start();
    this.commonservice.onconnonGet(URL).subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.guestDetails = res['Data'];
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

  onCheckedIn(roomId:any,bookingId:any) {
    let URL = `api/BookingList/updateBooking?roomid=${roomId}&bookingId=${bookingId}`;
    this.ngxService.start();
    this.commonservice.onconnonGet(URL).subscribe(
      (res: any) => {
        if (res['Success'] == true) {
          this.toster.success('CheckedIn Successfully.')
          this.router.navigate(['/checkedin']);
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

  onAddGuestModel() {
    this.formSubmit = true;

    let formObj = this.createUserForm.value;

    const formData = new FormData();


    formData.append('JsonObjStr', JSON.stringify(formObj));

    if (this.selectedPhotoFile && this.selectedPhotoFile.size > 0) {
      formData.append('DocumentName', this.selectedPhotoFile, this.selectedPhotoFile.name);
    }
   

    // formObj.CFEOrderDate = this.date.transform(formObj.CFEOrderDate, 'yyyy-MM-dd') || "not found"

    // console.log(formObj.CFEOrderDate)

    let url = `api/addBooking`;

    this.ngxService.start();

    if (this.formEdit == true) {
      this.commonservice
        .updatePut(`api/UpdateDepartmentData/`, formData)
        .subscribe(
          (res: any) => {
            this.ngxService.stop();

            if (res['Success']) {
              this.modalService.hide();
              this.toster.success('Request completed successfully!');
              this.createUserForm.reset();
              this.onGetAllUser();
              this.formEdit = false;
              this.formSubmit = false;
            } else {
              this.toster.error(res['ErrorMessage']);
            }
          },
          (error) => {
            this.ngxService.stop();
          }
        );
    } else {
      this.commonservice.addPost(url, formData).subscribe(
        (res: any) => {
          this.ngxService.stop();

          if (res['Success']) {
            this.modalService.hide();
            this.toster.success('Request completed successfully!');
            this.createUserForm.reset();
            this.onGetAllUser();
            this.formEdit = false;
            this.formSubmit = false;
          } else {
            this.toster.error(res['ErrorMessage']);
          }
        },
        (error: any) => {
          this.ngxService.stop();
        }
      );
    }
  }

  OnEditDept(template: TemplateRef<any>, dateObject: any, id: any) {
    this.formEdit = true;
    this.formSubmit = false;
    this.createUserForm.reset();
    this.id = id;

    this.createUserForm.setValue(element.pick(dateObject, ['DeptName']));

    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false,
    });
  }

  onDeleteAlert(template: TemplateRef<any>, selectedId: any) {
    this.SelectedUser = selectedId ? selectedId : -1;
    this.modalRef = this.modalService.show(template, {
      class: 'modal-sm',
      backdrop: 'static',
      keyboard: false,
    });
  }

  onDeleteDept() {
    // let url =`api/DeleteDepartmentData/`;
    let url = `api/DelateStatus/`;
    this.ngxService.start();
    this.commonservice.Delete(url, this.SelectedUser).subscribe(
      (res: any) => {
        this.ngxService.stop();
        this.modalService.hide();
        if (res['Success']) {
          this.toster.success(
            // 'User - ' + this.SelectedUser + ' deleted successfully.'
            res.Data
          );
          this.SelectedUser = undefined;
        } else {
          this.toster.error(
            // 'unable to delete User - ' + this.SelectedUser
            res.ErrorMessage
          );
        }
        this.onGetAllUser();
      },
      (error: any) => {
        this.ngxService.stop();
        this.toster.error('Error while deleteing User - ' + this.SelectedUser);
      }
    );
  }

  export(type: any) {
    const title = 'Department List';
    this.fileName = 'Department List';
    const header = ['SL', 'Department ID', 'Department Name'];
    let data: any = [];
    this.BookedList.forEach((element: any, key: any) => {
      let newArray = [];
      newArray.push(
        key + 1,
        element['DeptId'] ? element['DeptId'] : '---',
        element['DeptName'] ? element['DeptName'] : '---'
      );
      data[key] = newArray;
    });

    if (type == 'Excel') {
      this.expoerExcel(title, header, data);
    }
  }

  expoerExcel(title: any, header: any, data: any) {
    let workbook = new ExcelJS.Workbook();
    let worksheet = workbook.addWorksheet('Employee List');
    let titleRow = worksheet.addRow([title]);
    titleRow.getCell(1).fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: { argb: 'D2DCE2' },
      bgColor: { argb: 'FFFFFF00' },
    };
    // Set font, size and style in title row.
    worksheet.properties.defaultRowHeight = 20;
    // worksheet.properties.defaultRowWidth = 500;
    titleRow.font = {
      name: 'Calibri',
      family: 4,
      size: 14,
      underline: 'double',
      bold: true,
    };
    // Blank Row
    worksheet.addRow([]);
    worksheet.mergeCells('A1:U2');
    worksheet.addRow([]);

    worksheet.columns = [
      { width: 5 },
      { width: 20 },
      { width: 30 },
      // { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 },
      // { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 },
      // { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }
    ];

    let headerRow = worksheet.addRow(header);
    headerRow.font = { bold: true };
    headerRow.eachCell((cell: any, number: any) => {
      cell.fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'D2DCE2' },
        bgColor: { argb: 'FFFFFF00' },
      };
      cell.border = {
        top: { style: 'thin' },
        left: { style: 'thin' },
        bottom: { style: 'thin' },
        right: { style: 'thin' },
      };
    });

    worksheet.addRows(data);
    worksheet.addRows([]);
    worksheet.addRows([]);

    worksheet.getRow(1).alignment = { horizontal: 'left', vertical: 'middle' };
    worksheet.eachRow((row: any, number: any) => {
      row.eachCell((cell: any, number: any) => {
        cell.alignment = { horizontal: 'center', vertical: 'middle' };
      });
    });
    workbook.xlsx.writeBuffer().then((data: any) => {
      let blob = new Blob([data], {
        type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
      });
      fs.saveAs(blob, `${this.fileName}.xlsx`);
    });
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
    const fileInput = document.getElementById('IDProofPhoto');
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
