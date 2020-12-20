import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
  NgbActiveModal,
  NgbModal,
  NgbModalRef,
} from '@ng-bootstrap/ng-bootstrap';
import { DialogInformationComponent } from 'src/app/core/components/dialog-information/dialog-information.component';
import { ITimeWorking } from '../../interfaces/iTimeWorking';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { EmployeeService } from '../../services/employee/employee.service';
import { ImageService } from '../../services/image/image.service';
@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss'],
})
/**
 * Popup that contains the user information.
 */
export class EmployeeInfoComponent implements OnInit {
  modal: NgbModalRef;
  imageChange: boolean = false;
  modalRef: DialogInformationComponent;
  employee: Employee;
  imageValue: Image;
  formValues: FormGroup;
  timeWorking: ITimeWorking = {
    years: 0,
    months: 0,
    days: 0,
  };
  readonly = {
    empId: true,
    name: true,
    phone: true,
    email: true,
    hireDate: true,
    managerId: true,
  };
/**
 * Creates a Popup with an employee info.
 * @param activeModal modal active at the moment.
 * @param imageService service to get or post the employee image.
 * @param employeeService service to put or delete the user info.
 * @param modalService service that manages the popups.
 */
  constructor(
    public activeModal: NgbActiveModal,
    private readonly imageService: ImageService,
    private readonly employeeService: EmployeeService,
    private readonly modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.imageValue = this.employee.picture;
    this.employee.hireDate = new Date(this.employee.hireDate);

    this.formValues = new FormGroup({
      employeeId: new FormControl(this.employee.employeeId),
      name: new FormControl(this.employee.name),
      phone: new FormControl(this.employee.phoneNumber, [
        Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-s./0-9]*$'),
      ]),
      email: new FormControl(this.employee.email, [Validators.email]),
      hire: new FormControl(this.employee.hireDate),
      managerId: new FormControl(this.employee.managerId),
    });
    const today = new Date();

    this.timeWorking = {
      years: today.getFullYear() - this.employee.hireDate.getFullYear(),
      months: today.getMonth() - this.employee.hireDate.getMonth(),
      days: today.getDate() - this.employee.hireDate.getDate(),
    };
  }
  /**
   * Loads image to the server.
   * @param event event containing the image.
   */
  async onFileSelected(event) {
    const file: File = <File>event.target.files[0];
    const fd: FormData = new FormData();

    fd.append('image', file, file.name);

    this.imageService.post(fd).subscribe((response) => {
      this.imageValue = response;
      this.imageChange = true;
    });
  }
  /**
   * Updates the Form Values.
   */
  update() {
    if (
      (this.formValues.touched && this.formValues.valid) ||
      this.imageChange
    ) {
      const values = this.formValues.value;
      let value = new Employee(
        values.employeeId,
        values.name,
        this.imageValue,
        values.phone,
        values.email,
        values.hire
      );
      if (values.managerId !== '') value.managerId = values.managerId;
      value.id = this.employee.id;
      this.employeeService.put(value).subscribe((res) => {
        this.modal = this.modalService.open(DialogInformationComponent, {
          centered: true,
          size: 'sm',
        });
        this.modalRef = this.modal.componentInstance;
        this.modalRef.title = 'Success!';
        this.modalRef.body = `Employee ${res.name}, ID: ${res.employeeId}, has been updated`;
        this.modal.closed.subscribe(() => {
          this.activeModal.close();
          window.location.reload();
        });
      });
    } else {
      this.modal = this.modalService.open(DialogInformationComponent, {
        centered: true,
        size: 'sm',
      });
      this.modalRef = this.modal.componentInstance;
      this.modalRef.title = 'Error';
      this.modalRef.body = `Employee ${this.employee.name}'s info hasn't changed`;
    }
  }
  /**
   * Deletes the employee.
   */
  async deleteEmp() {
    this.modal = this.modalService.open(DialogInformationComponent, {
      centered: true,
      size: 'sm',
    });
    this.modalRef = this.modal.componentInstance;
    this.modalRef.needsConfirmation = true;
    this.modalRef.title = 'WARNING!';
    this.modalRef.body = `Are you sure you want to delete the employee ${this.employee.name}?`;
    let deleted: boolean = false;
    await this.closeValue().then((value) => (deleted = value));

    if (deleted) {
      this.employeeService.delete(this.employee.id).subscribe((res) => {
        this.modal = this.modalService.open(DialogInformationComponent, {
          centered: true,
          size: 'sm',
        });
        this.modalRef = this.modal.componentInstance;
        this.modalRef.title = 'Success!';
        this.modalRef.body = `Employee ${res.name}, ID: ${res.employeeId}, has been deleted`;
        this.modal.closed.subscribe(() => window.location.reload());
      });
    }
  }
  /**
   * Returns popup value when popup is closed.
   */
  async closeValue(): Promise<boolean> {
    return this.modal.closed.toPromise();
  }
}
