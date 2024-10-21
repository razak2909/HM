import { Component, OnInit, TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {
  IsEdit: boolean = false;


  modalRef: BsModalRef | null = null;
  DepartmentList: any;
  router: any;
  createRoleForm: any = FormGroup;

export(arg0: string) {
throw new Error('Method not implemented.');
}

  constructor(private ngxService : NgxUiLoaderService,
    private toster : ToastrService,
    private commonservice : CommonserviceService,
    public modalService : BsModalService) { }

    ngOnInit(): void {
      this.onGetAllUser();
      this.createRoleForm = new FormGroup({
        RoleName :new FormControl(""),
        Description : new FormControl("")
      })
    }

    onGetAllUser(){
      let url = `api/UserRole`
      this.ngxService.start();
      this.commonservice.getBookedList(url)
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

    onAddRoleModel() {
      let formObj = this.createRoleForm.value;
      const formData = new FormData();
      formData.append('JsonObjStr', JSON.stringify(formObj));
  
      if (this.IsEdit) {
        let URL = `api/RoomTypes`;
        this.ngxService.start();
        this.commonservice.updatePut(URL, formObj).subscribe(
          (res: any) => {
            this.ngxService.stop();
            if (res['Success']) {
              this.createRoleForm.reset();
              this.toster.success('Request completed successfully!');
              this.onGetAllUser();
            } else {
              this.toster.error("Error :" + res['ErrorMessage']);
            }
            this.modalService.hide();
            this.IsEdit = false;
          },
          (error: any) => {
            this.ngxService.stop();
          }
        );
      } else {
        let URL = `api/UserRole`;
        this.ngxService.start();
        this.commonservice.addPost(URL, formData).subscribe(
          (res: any) => {
            this.ngxService.stop();
            if (res['Success']) {
              this.createRoleForm.reset();
              this.toster.success('Request completed successfully!');
              this.onGetAllUser();
            } else {
              this.toster.error("Error :" + res['ErrorMessage']);
            }
            this.modalService.hide();
          },
          (error: any) => {
            this.ngxService.stop();
          }
        );
      }
    
    }

    onAddUserModal(template: TemplateRef<any>) {
      this.createRoleForm.reset();
      this.onGetAllUser();
      this.IsEdit = false;
      this.modalRef = this.modalService.show(template, {
        class: 'modal-md modal-dialog modal-dialog-centered',
        backdrop: 'static',
        keyboard: false
      });
    }


    
}
