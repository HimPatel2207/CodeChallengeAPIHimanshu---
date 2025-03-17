import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CompanyDataService } from '../../../DemoServices/company-data.service';
import { CompanyModel } from '../../../Models/company-model.model';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';

/**
 * @title Basic use of `<table mat-table>`
 */

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  standalone: true,
  imports: [MatTableModule,MatPaginatorModule]
})
export class TableComponent implements OnInit {
  displayedColumns = ['Id', 'Name', 'Exchange', 'Ticker' ,'Isin', 'Website'];
  dataSource: MatTableDataSource<CompanyModel> = new MatTableDataSource<CompanyModel>();

  constructor(private companyService: CompanyDataService) {}

  ngOnInit() {
    this.GetCompanyList();    
  }

  GetCompanyList() {
    this.companyService.getAllcompanyList().subscribe((companyData: any) => {
      this.dataSource.data = companyData;
      console.log(this.dataSource.data);
    });
  }
}