import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { Subject } from 'rxjs';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { BrowserstorageService } from 'src/app/shared/non-http/browserstorage.service';
import * as element from 'lodash';

// >> export excel/pdf imports
import * as ExcelJS from 'exceljs';
import * as fs from 'file-saver';
declare var require: any;
var jsPDF = require('jspdf');
require('jspdf-autotable');
// export excel/pdf imports <<

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  modalRef: BsModalRef | null = null;

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> | any = new Subject();

  createUserForm: any = FormGroup;
  allUser: any;
  SelectedUser: any;
  allUserRole: any;
  filteredUserRole: any;
  isShowPass = false;

  formSubmitted: boolean = false;
  formEdit: boolean = false;
  fileName!: string;

  isEdit : boolean = false;

  constructor(
    public modalService: BsModalService,
    private ngxService: NgxUiLoaderService,
    private commonService: CommonserviceService,
    private toastr: ToastrService,
    private browserStorageService: BrowserstorageService,
  ) {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      scrollX: false,
      processing: true,
      "order": [],                       // sorting 2nd column
      "columnDefs": [
        { "orderable": false, "targets": "_all" } // Applies the option to all columns
      ]
    };
  }

  ngOnInit(): void {
    this.dtTrigger.next();
    this.createUserForm = new FormGroup({
      UserId: new FormControl("", [Validators.required, Validators.pattern('^[a-zA-Z- ]*$')]),
      Password: new FormControl("", this.formEdit ? [Validators.pattern("^[a-zA-Z0-9@]{3,15}$")] : [Validators.required, Validators.pattern("^[a-zA-Z0-9@]{3,15}$")]),
      EmailId: new FormControl("", [Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$')]),
      RoleName : new FormControl(""),
      Age : new FormControl("", [ Validators.pattern("^[0-9]*$")]),
      PresentAddress : new FormControl(""),
      MobileNo :new FormControl("",[Validators.required,Validators.pattern('^[0-9]{10}$')]),
      PermanentAddress : new FormControl("")


      // Status: new FormControl(false),
      // CreatedBy: new FormControl(null),
      // ModifiedBy: new FormControl(null),
    });

    this.onGetAllUser();

    
  }

  onGetAllUser() {
    let URL = 'api/User/getAllUser';
    this.ngxService.start();
    this.commonService.getUserList(URL)
      .subscribe(
        (res: any) => {
          //  $('#UserTable').DataTable().destroy();
          if (res['Success'] == true) {
            $('#UserTable').DataTable().destroy();
            this.allUser = res['Data'];
            this.dtTrigger.next();

            setTimeout(() => {
              $('table#UserTable.dataTable').wrap(
                "<div class='scrolledTable'></div>"
              );
              this.ngxService.stop();
            }, 150);
          } else {
            this.toastr.error('Error getting data.');
            this.ngxService.stop();
          }
        },
        (error) => {
          this.ngxService.stop();
        }
      );
  }

  onGetAllUserRole() {
    let URL = `api/UserRole`;
    this.ngxService.start();
    this.commonService.getUserList(URL)
      .subscribe(
        (res: any) => {
          if (res['Success'] == true) {
            this.filteredUserRole = this.allUserRole = res['Data'];
          } else {
            this.toastr.error('Error getting data.');
          }
          this.ngxService.stop();
        },
        (error) => {
          this.ngxService.stop();
        }
      );
  }

  onSearchUserRole(event: any) {
    if (event.target.value) {
      const val = event.target.value.toLowerCase();
      this.filteredUserRole = this.allUserRole.filter(function (d: any) {
        return d.RoleName.toLowerCase().indexOf(val) !== -1 || !val;
      });
    } else
      if (this.filteredUserRole != this.allUserRole) {
        this.filteredUserRole = this.allUserRole;
      }
  }

  onAddUserModal(template: TemplateRef<any>) {

    this.formEdit = false;
    this.formSubmitted = false;
    this.createUserForm.reset();
    this.onGetAllUserRole();


    this.createUserForm.get('UserId')?.enable();

    this.createUserForm.patchValue({
      CreatedBy: this.browserStorageService.loggedInUser,
      ModifiedBy: this.browserStorageService.loggedInUser,
    });

    this.modalRef = this.modalService.show(template,
      {
        class:'modal-lg modal-dialog modal-dialog-centered',
        backdrop: 'static',
        keyboard: false
      });
  }

  onAddUser() {
    this.formSubmitted = true;

    // this.createUserForm.patchValue({
    //   Status: true,
    //   CreatedBy: this.browserStorageService.loggedInUser,
    //   ModifiedBy: this.browserStorageService.loggedInUser
    // });

    this.createUserForm.get('UserId')?.enable();

    let formObj = this.createUserForm.value;

    // formObj.isEdit = this.isEdit;
    const formData = new FormData();
    formData.append('JsonObjStr', JSON.stringify(formObj));

    let url = `api/User/AddEdit?IsEdit=${this.isEdit}`;

    console.log("test: ",formObj)
    this.ngxService.start();
    this.commonService.addUser(formData, url)
      .subscribe(
        (res: any) => {
          this.ngxService.stop();

          if (res['Success']) {
            this.modalService.hide();
            this.toastr.success(res['Data']);
            this.createUserForm.reset();
            this.onGetAllUser();
            this.formEdit = false;
            this.formSubmitted = false;
          }
          else {
            this.toastr.error(res['ErrorMessage']);
          }
        },
        error => {
          this.ngxService.stop();
        }
      );
  }

  onEditUser(template: TemplateRef<any>, dataObject: any) {
    this.formEdit = true;
    this.formSubmitted = false;
    this.createUserForm.reset();

    this.isEdit = true;

    if (!this.allUserRole || this.allUserRole.length == 0) {
      this.onGetAllUserRole();
    }

    this.createUserForm.setValue(
      element.pick(dataObject,
        [
          'UserId',
          'Password',
          'EmailId',
          'MobileNo',
          'RoleName', 
          'Age',
          'PresentAddress',
          'PermanentAddress'
         ])
    );

    this.createUserForm.get('UserId')?.disable();
    this.modalRef = this.modalService.show(template,
      {
        class: 'modal-lg modal-dialog modal-dialog-centered',
        backdrop: 'static',
        keyboard: false
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

  onDeleteUser() {
    let url = `api/User/Delete?Key=${this.SelectedUser}`;
    this.ngxService.start();
    this.commonService.deleteR(url)
      .subscribe(
        (res: any) => {
          this.ngxService.stop();
          this.modalService.hide();
          if (res['Success']) {
            this.toastr.success(
              'User - ' + this.SelectedUser + ' deleted successfully.'
            );
            this.SelectedUser = undefined;
          } else {
            this.toastr.error(
              'unable to delete User - ' + this.SelectedUser
            );
          }
          this.onGetAllUser();
        },
        (error : any) => {
          this.ngxService.stop();
          this.toastr.error(
            'Error while deleteing User - ' + this.SelectedUser
          );
        }
      );
  }

  export(type: any) {
    const title = 'User';
    this.fileName = "User";
    const header = ["#", 'UserId', 'EmailId', 
    ];
    let data: any = [];
    this.allUser.forEach((element: any, key: any) => {
      let newArray = [];
      newArray.push(
        key + 1,
      
        element['UserId'] ? element['UserId'] : '-',
     
        element['EmailId'] ? element['EmailId'] : '-',

      )
      data[key] = newArray;
    });

    if (type == 'Excel') {
      this.expoerExcel(title, header, data);
    }

    if (type == 'PDF') {
      this.exportPDF(title, header, data);
    }
  }

  expoerExcel(title: any, header: any, data: any) {
    let workbook = new ExcelJS.Workbook();
    let worksheet = workbook.addWorksheet('User');
    let titleRow = worksheet.addRow([title]);
    titleRow.getCell(1).fill = {
      type: 'pattern',
      pattern: 'solid',
      fgColor: { argb: 'D2DCE2' },
      bgColor: { argb: 'FFFFFF00' }
    };
    // Set font, size and style in title row.
    worksheet.properties.defaultRowHeight = 20;
    // worksheet.properties.defaultRowWidth = 500;
    titleRow.font = { name: 'Calibri', family: 4, size: 14, underline: 'double', bold: true };
    // Blank Row
    worksheet.addRow([]);
    worksheet.mergeCells('A1:F2');
    worksheet.addRow([]);

    worksheet.columns = [
      { width: 5 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 }, { width: 20 },
    ];

    let headerRow = worksheet.addRow(header);
    headerRow.font = { bold: true };
    headerRow.eachCell((cell: any, number: any) => {
      cell.fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'D2DCE2' },
        bgColor: { argb: 'FFFFFF00' }
      }
      cell.border = { top: { style: 'thin' }, left: { style: 'thin' }, bottom: { style: 'thin' }, right: { style: 'thin' } }
    });

    worksheet.addRows(data);
    worksheet.addRows([]);
    worksheet.addRows([]);

    worksheet.getRow(1).alignment = { horizontal: 'left', vertical: 'middle' };
    worksheet.eachRow((row: any, number: any) => {
      row.eachCell((cell: any, number: any) => {
        cell.alignment = { horizontal: 'center', vertical: 'middle' }
      });
    });
    workbook.xlsx.writeBuffer().then((data: any) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, `${this.commonService.Date()}_${this.fileName}.xlsx`);

    });
  }

  exportPDF(title: any, header: any, data: any) {

    const doc = new jsPDF('l', 'pt', 'tabloid');
    doc.setFontType("underline");
    doc.text(512, 60, title)

    // Optional - set properties on the document
    doc.setProperties({
      title: `User`,
      alignment: `center`
    });

    doc.autoTable({
      tableWidth: 'auto',
      head: [header],
      margin: { top: 80 },
      headStyles: { europe: { halign: 'center' } },
      body: data,
      columnStyles: {
        0: { cellWidth: 60 },
        1: { cellWidth: 90 },
        2: { cellWidth: 90 },
        3: { cellWidth: 90 },
        4: { cellWidth: 90 },
        5: { cellWidth: 90 },
        6: { cellWidth: 90 },
        7: { cellWidth: 90 },
        8: { cellWidth: 90 },
        9: { cellWidth: 90 },
        10: { cellWidth: 90 },
        11: { cellWidth: 90 },

      },
      bodyStyles: { fontSize: 11, lineWidth: 1, cellPadding: 5 } // Font Size for Rows
    });
    doc.save(`${this.commonService.Date()}_${this.fileName}.pdf`);
  }

}
