import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { BrowserstorageService } from 'src/app/shared/non-http/browserstorage.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-viewdetails1',
  templateUrl: './viewdetails1.component.html',
  styleUrls: ['./viewdetails1.component.scss']
})
export class Viewdetails1Component implements OnInit {

  guestDetails: any;
  guestId: any;
modalService: any;
selectedPhotoFileUrl: any;
ditem: any;
  selectedPhotoFile: any;
  modalRef: any;
ViewDetailsList: any;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private commonservice: CommonserviceService,
    private ngxService: NgxUiLoaderService,
    private toster: ToastrService,
    public browserStorageService: BrowserstorageService,
    public date: DatePipe
  ) { }

  ngOnInit(): void {
    this.guestId = this.route.snapshot.paramMap.get('guestId');
    this.onGetAllUser();
  }

  goBackToCheckin() {
    this.router.navigate(['/booked']);
  }

  onGetAllUser() {
    let url = `api/ViewDetails?Id=${this.guestId}`;
    this.ngxService.start();
    this.commonservice.getBookedList(url)
      .subscribe(
        (data: any) => {
          if (data['Success'] === true) {
            console.log('Data: ', data.Data);
            this.guestDetails = data.Data;

            setTimeout(() => {
              this.ngxService.stop();
            }, 150);
          } else {
            this.toster.error('Error Getting Data');
            this.ngxService.stop();
          }
        },
        (error : any) => {
          this.toster.error('Error occurred');
          this.ngxService.stop();
        }
      );
  }

  photomodel1(template: TemplateRef<any>,IDProofPhoto:any) {
    this.selectedPhotoFile = IDProofPhoto;
    this.selectedPhotoFileUrl = environment.baseUrl+'ProjectFiles/GuestIdProof/'+this.selectedPhotoFile;
    this.modalRef = this.modalService.show(template,
      {
        class: 'modal-lg modal-dialog modal-dialog-centered',
        backdrop: 'static',
        keyboard: false
      })
  }

}
