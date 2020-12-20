import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee/employee.service';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeInfoComponent } from '../employee-info/employee-info.component';
import { DialogInformationComponent } from 'src/app/core/components/dialog-information/dialog-information.component';
import { NgxSpinnerService } from 'ngx-bootstrap-spinner';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
/**
 * Component that show the employee list
 */
export class EmployeeListComponent implements OnInit {
  public modal: NgbModalRef;
  public modalRefDialog: DialogInformationComponent;
  public allEmployees: Employee[];
  public employees: Employee[];
  public filter: string;
  public modalRef: EmployeeInfoComponent;
  /**
   * Creates an EmployeeComponent
   * @param service service that gets the employees.
   * @param modalService service that gets the modals (popups).
   */
  constructor(
    service: EmployeeService,
    private readonly modalService: NgbModal,
    private spinner: NgxSpinnerService
  ) {
    this.spinner.show();
    service.getAll().subscribe((result) => {
      this.allEmployees = result;
      this.search();
    });
  }

  ngOnInit(): void {}

  /**
   * Opens a pop up with the given employee information.
   * @param employee employee information.
   */
  open(employee: Employee) {
    this.modalRef = this.modalService.open(EmployeeInfoComponent, {
      centered: true,
      size: 'lg',
      scrollable: true,
    }).componentInstance;
    this.modalRef.employee = employee;
  }
  /**
   * Searches an employee with the filter specified.
   */
  search(): void {
    this.employees = this.allEmployees
      .filter(
        (employee) =>
          employee.name.toLowerCase().includes(this.filter.toLowerCase()) ||
          employee.employeeId.toLowerCase().includes(this.filter.toLowerCase())
      )
      .sort((a, b) => (a.name < b.name ? -1 : 1));
    if ((this.employees.length < 1) && (this.allEmployees.length > 0)) {
      this.modal = this.modalService.open(DialogInformationComponent, {
        centered: true,
        size: 'sm',
      });
      this.modalRefDialog = this.modal.componentInstance;
      this.modalRefDialog.title = 'Error';
      this.modalRefDialog.body = `Employee with ${this.filter} was not found.`;
    }
  }
}
