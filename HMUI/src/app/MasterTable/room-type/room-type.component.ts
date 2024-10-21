import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import * as element from 'lodash';

@Component({
  selector: 'app-room-type',
  templateUrl: './room-type.component.html',
  styleUrls: ['./room-type.component.scss']
})
export class RoomTypeComponent implements OnInit {
// Fetch all Room Types
export(arg0: string) {
throw new Error('Method not implemented.');
}
  selectedRoomTypeId: any;
  roomTypeList: any;  // List of Room Types
  createRoomTypeForm: any = FormGroup;
  modalRef: BsModalRef | null = null;
  IsEdit: boolean = false;
  formSubmitted: any;

  constructor(
    private ngxService: NgxUiLoaderService,
    private toastr: ToastrService,
    private commonservice: CommonserviceService,
    public modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.onGetAllRoomTypes();

    // Initialize the form
    this.createRoomTypeForm = new FormGroup({
      RoomType: new FormControl(),
      Price: new FormControl()
    });
  }

  // Fetch all Room Types
  onGetAllRoomTypes() {
    let url = `api/RoomTypes`;
    this.ngxService.start();
    this.commonservice.getBookedList(url)
      .subscribe(
        (data: any) => {
          if (data['Success'] === true) {
            this.roomTypeList = data.Data;

            setTimeout(() => {
              this.ngxService.stop();
            }, 150);
          } else {
            this.toastr.error('Error Getting Data');
            this.ngxService.stop();
          }
        },
        (error) => {
          this.ngxService.stop();
        }
      );
  }

  // Add RoomType modal logic
  onAddRoomTypeModel() {
    let formObj = this.createRoomTypeForm.value;
    const formData = new FormData();
    formData.append('JsonObjStr', JSON.stringify(formObj));

    if (this.IsEdit) {
      let URL = `api/RoomTypes?id=${this.selectedRoomTypeId}`;
      this.ngxService.start();
      this.commonservice.updatePut(URL, formObj).subscribe(
        (res: any) => {
          this.ngxService.stop();
          if (res['Success']) {
            this.createRoomTypeForm.reset();
            this.toastr.success('Request completed successfully!');
            this.onGetAllRoomTypes();
          } else {
            this.toastr.error("Error :" + res['ErrorMessage']);
          }
          this.modalService.hide();
          this.IsEdit = false;
        },
        (error: any) => {
          this.ngxService.stop();
        }
      );
    } else {
      let URL = `api/RoomTypes`;
      this.ngxService.start();
      this.commonservice.addPost(URL, formObj).subscribe(
        (res: any) => {
          this.ngxService.stop();
          if (res['Success']) {
            this.createRoomTypeForm.reset();
            this.toastr.success('Request completed successfully!');
            this.onGetAllRoomTypes();
          } else {
            this.toastr.error("Error :" + res['ErrorMessage']);
          }
          this.modalService.hide();
        },
        (error: any) => {
          this.ngxService.stop();
        }
      );
    }
  }

  // Open Add RoomType Modal
  onAddRoomType(template: TemplateRef<any>) {
    this.createRoomTypeForm.reset();
    this.onGetAllRoomTypes();
    this.IsEdit = false;
    this.modalRef = this.modalService.show(template, {
      class: 'modal-md modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false
    });
  }

  // Edit RoomType modal logic
  onEditRoomType(template: TemplateRef<any>, dataObject: any) {
    this.IsEdit = true;
    this.formSubmitted = false;
    this.createRoomTypeForm.reset();
    this.selectedRoomTypeId = dataObject.RoomTypeId;

    this.onGetAllRoomTypes();

    this.createRoomTypeForm.setValue(
      element.pick(dataObject, [
        'RoomType',
        'Price'
      ])
    );

    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false
    });
  }

  // Delete RoomType logic
  onDeleteRoomType(template: TemplateRef<any>, dataObject: any) {
    this.formSubmitted = false;
    this.createRoomTypeForm.reset();
    this.selectedRoomTypeId = dataObject.RoomTypeId;

    this.modalRef = this.modalService.show(template, {
      class: 'modal-lg modal-dialog modal-dialog-centered',
      backdrop: 'static',
      keyboard: false
    });
  }

  // Confirm deletion
  confirmDelete() {
    let url = `api/RoomTypes?id=${this.selectedRoomTypeId}`;
    this.commonservice.deleteR(url).subscribe(
      (response: any) => {
        console.log("RoomType deleted successfully!", response);
        this.modalRef?.hide(); // Close modal if exists
        this.onGetAllRoomTypes(); // Refresh RoomType list
      },
      (error: any) => {
        console.error("Error deleting RoomType", error);
      }
    );
  }
}
