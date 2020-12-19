import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
})
export class EmployeeListComponent implements OnInit {
  public allEmployees: Employee[];
  public employees: Employee[];
  public filter: string;

  constructor(private readonly service: EmployeeService) {
    service.getAll().subscribe((result) => {
      this.allEmployees = result;
      this.employees = this.allEmployees;
      this.employees.sort((a, b) => (a.name < b.name ? -1 : 1));
    });
  }

  ngOnInit(): void {

  }

  search(): void {
    this.employees = this.allEmployees
      .filter(
        (employee) =>
          employee.name.includes(this.filter) ||
          employee.employeeId.includes(this.filter)
      )
      .sort((a, b) => (a.name < b.name ? -1 : 1));
  }
}
