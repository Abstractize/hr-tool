import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee/employee.service'

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {

  constructor(private readonly employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.GetAll().subscribe(data => {
      console.log(data);
    })
  }

}
