import { Component, OnInit,TemplateRef } from '@angular/core';
import { CommonserviceService } from 'src/app/shared/http/commonservice.service';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { ToastrService } from 'ngx-toastr';
import { RouterModule } from '@angular/router';

import * as ExcelJS from 'exceljs';
import * as fs from 'file-saver';
declare var require: any;
var jsPDF = require('jspdf');


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
totalBookings: any;
TotalEmployeesCount: any;
totalEmployees: any;
errorMessage:any;
ViewBag: any;
currentTime: string = '';
currentDate: string= '';
timer: any;
user: any;


onAddGuestModel() {
throw new Error('Method not implemented.');
}

  fileName !: string;
  alluser : any;
  dtOptions: DataTables.Settings = {};
modalService: any;
createUserForm: any;

  constructor(private commonservice : CommonserviceService,
              private ngxService: NgxUiLoaderService,
              private toster :ToastrService, 

  ) { }

  ngOnInit(): void {
    this.totalEmployeesCount();
    this.onGetTotalBookings();
    this.updateClock();
    this.timer = setInterval(() => {
      this.updateClock();
    }, 1000);
  }

  ngOnDestroy() {
    clearInterval(this.timer); // Clear the interval on component destruction
  }

  private updateClock() {
    const now = new Date();
    this.currentTime = now.toLocaleTimeString(); // Format time as needed
    this.currentDate = now.toLocaleDateString(); // Format date as needed
  }


    alldata : any = [];

  onGetTotalBookings(){
    let url = `api/AllDashboardData`
    this.ngxService.start();
    this.commonservice.getBookedList(url)
    .subscribe(
      (data : any)=>{
        // if(data['Success'] == true){
        if(data){
          this.alldata = data.Data;

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

  getDeptName(depId : any){
    for(var dn of this.alldata.DashBoardData){
      if(dn.DeptId == depId){
        return dn.DeptName
      }
    }
  }

  export(type: any) {
    const title = 'Dashboard Data List';
    this.fileName = "Dashboard Data List";
    const header = ["SL", 'Employee ID', 'Employee Name', 'Dept Id','Dept Name','Data Of Joining','Photo File Name'];
    let data: any = [];
    this.alldata.DashBoardData.forEach((element: any, key: any) => {
      let newArray = [];
      newArray.push(
        key + 1,
        element['EmpId'] ? element['EmpId'] : '---',
        element['EmpName'] ? element['EmpName'] : '---',
        element['DeptId'] ? element['DeptId'] : '---',
        element['DeptName'] ? element['DeptName'] : '---',
        element['DateOfJoining'] ? element['DateOfJoining'] : '---',
        element['PhotoFileName'] ? element['PhotoFileName'] : '---',
      )
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
      bgColor: { argb: 'FFFFFF00' }
    };
    // Set font, size and style in title row.
    worksheet.properties.defaultRowHeight = 20;
    // worksheet.properties.defaultRowWidth = 500;
    titleRow.font = { name: 'Calibri', family: 4, size: 14, underline: 'double', bold: true };
    // Blank Row
    worksheet.addRow([]);
    worksheet.mergeCells('A1:U2');
    worksheet.addRow([]);

    worksheet.columns = [
      { width: 5 }, { width: 20 }, { width: 30 }, { width: 20 }, { width: 30 }, { width: 30 }, { width: 30 }, { width: 20 }, 
      // { width: 20 }, { width: 20 },
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
      fs.saveAs(blob, `${this.fileName}.xlsx`);

    });
  }


//   totalBooking(): void {
//         const url = 'api/DeveloperCount';
//         const data = ''; // No additional data needed for this request
    
//         this.commonservice.getTotalBookingCount(url).subscribe({
//           next: (response: any) => {
//             if (response.Success) {
//               this.totalBooking = response.Data;
//             } else {
//               this.errorMessage = 'Failed to retrieve developer count';
//             }
//           },
//           error: (error: any) => {
//             console.error('Error fetching developer count:', error);
//             this.errorMessage = 'An error occurred while fetching developer count';
//           }
//         });
//       }

totalEmployeesCount(): void {
  const url = 'api/getTotalUserCount';
  const data = ''; // No additional data needed for this request

  this.commonservice.getTotalEmployeeCount(url).subscribe({
    next: (response: any) => {
      if (response.Success) {
        this.TotalEmployeesCount = response.Data;
      } else {
        this.errorMessage = 'Failed to retrieve Employee count';
      }
    },
    error: (error: any) => {
      console.error('Error fetching Employee count:', error);
      this.errorMessage = 'An error occurred while fetching Employee count';
    }
     });
      }
 
}
