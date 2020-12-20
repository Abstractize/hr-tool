import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee/employee.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeInfoComponent } from '../employee-info/employee-info.component';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  public allEmployees: Employee[];
  public employees: Employee[];
  public filter: string;
  public modalRef: EmployeeInfoComponent;

  constructor(
    service: EmployeeService,
    private readonly modalService: NgbModal
    ) {
    service.getAll().subscribe((result) => {
      this.allEmployees = result;
      this.employees = this.allEmployees;
      this.employees.sort((a, b) => (a.name < b.name ? -1 : 1));
    });
  }

  ngOnInit(): void {

  }

  open(employee: Employee) {
    this.modalRef = this.modalService
      .open(EmployeeInfoComponent, { centered: true, size: 'lg', scrollable: true })
      .componentInstance;
    this.modalRef.employee = employee;
  }

  search(): void {
    this.employees = this.allEmployees
      .filter(
        (employee) =>
          employee.name.toLowerCase().includes(this.filter.toLowerCase()) ||
          employee.employeeId.toLowerCase().includes(this.filter.toLowerCase())
      )
      .sort((a, b) => (a.name < b.name ? -1 : 1));
  }
}
