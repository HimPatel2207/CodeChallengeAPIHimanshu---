import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CompanyDataService } from '../../../DemoServices/company-data.service';
import { CompanyModel } from '../../../Models/company-model.model';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatButtonModule} from '@angular/material/button';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatCardModule} from '@angular/material/card';

/**
 * @title Basic use of `<table mat-table>`
 */

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
  standalone: true,
  imports: [MatTableModule,MatPaginatorModule,MatButtonModule,MatProgressBarModule,MatCardModule]
})
export class TableComponent implements OnInit {
  displayedColumns = ['Id', 'Name', 'Exchange', 'Ticker' ,'Isin', 'Website','Actions'];
  dataSource: MatTableDataSource<CompanyModel> = new MatTableDataSource<CompanyModel>();

  isHidden: boolean = false;

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

  AddCompany() {
    alert('Add Company code need to add here');    
  }

  EditCompany() {
    alert('Edit Company code need to add here');    
  }

  DeleteCompany(id: number) {
    this.companyService.deleteCompanyById(id).subscribe(() => {
      this.GetCompanyList();
    });
  }

}