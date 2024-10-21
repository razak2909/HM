import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { BrowserstorageService } from 'src/app/shared/non-http/browserstorage.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-viewdetails',
  templateUrl: './viewdetails.component.html',
  styleUrls: ['./viewdetails.component.scss']
})
export class ViewdetailsComponent implements OnInit {

  guestDetails: any;
  guestId: any;
modalService: any;
selectedtedPhoto : any;
selectedPhotoFileUrl: any;
ditem: any;
  selectedPhotoFile: any;
  modalRef: any;
ViewDetailsList: any;
Guest:any;

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

  goBackToBooked() {
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
            this.selectedPhotoFileUrl = environment.baseUrl+"ProjectFiles/GuestIdProof/"+this.guestDetails.IDProofPhoto;

            setTimeout(() => {
              this.ngxService.stop();
            }, 150);
          } else {
            this.toster.error('Error Getting Data');
            this.ngxService.stop();
          }
        },
        (error) => {
          this.toster.error('Error occurred');
          this.ngxService.stop();
        }
      );
  }

}
