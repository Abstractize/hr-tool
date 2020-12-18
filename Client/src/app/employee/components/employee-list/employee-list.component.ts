import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee/employee.service'

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
