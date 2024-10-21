import { Component, OnInit } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { BrowserstorageService } from 'src/app/shared/non-http/browserstorage.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-viewdetails2',
  templateUrl: './viewdetails2.component.html',
  styleUrls: ['./viewdetails2.component.scss']
})
export class Viewdetails2Component implements OnInit {

  guestDetails: any;
  guestId: any;
  selectedtedPhoto : any;
  selectedPhotoFileUrl: any;
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



  goBackToCheckout() {
    this.router.navigate(['/checkedout']);
  }

  onGetAllUser() {
    console.log("Val 43");
    let url = `api/ViewDetails?Id=${this.guestId}`;
    this.selectedPhotoFileUrl = environment.baseUrl+"ProjectFiles/GuestIdProof/";

    this.ngxService.start();
    this.commonservice.getBookedList(url)
      .subscribe(
        (data: any) => {
          if (data['Success'] === true) {
            this.guestDetails = data.Data;
            console.log("val")

            this.selectedtedPhoto = environment.baseUrl+'ProjectFiles/'+'GuestIdProof/'+this.guestDetails.IDProofPhoto;
            console.log("val", this.selectedtedPhoto)

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
