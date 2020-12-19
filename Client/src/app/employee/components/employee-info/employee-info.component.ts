import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { ImageService } from '../../services/image/image.service';

interface ITimeWorking{
  years: number;
  months: number;
  days: number;
}
@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss'],
})
export class EmployeeInfoComponent implements OnInit {
  employee: Employee;
  imageValue: Image;
  formValues: FormGroup;
  timeWorking: ITimeWorking = {
    years: 0,
    months: 0,
    days: 0
  };
  readonly = {
    empId: true,
    name: true,
    phone: true,
    email: true,
    hireDate: true,
    managerId: true,
  };

  constructor(
    public activeModal: NgbActiveModal,
    private readonly imageService: ImageService
  ) {}

  ngOnInit(): void {
    this.imageValue = this.employee.picture;
    this.employee.hireDate = new Date(this.employee.hireDate);
    this.formValues = new FormGroup({
      employeeId: new FormControl(this.employee.employeeId, [
        Validators.required,
      ]),
      name: new FormControl(this.employee.name),
      phone: new FormControl(this.employee.phoneNumber, [
        Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-s./0-9]*$'),
      ]),
      email: new FormControl(this.employee.email, [
        Validators.email,
      ]),
      hire: new FormControl(this.employee.hireDate),
      managerId: new FormControl(this.employee.managerId),
    });
    const today = new Date();

    this.timeWorking = {
      years: today.getFullYear() - this.employee.hireDate.getFullYear(),
      months: today.getMonth() - this.employee.hireDate.getMonth(),
      days: today.getDate() - this.employee.hireDate.getDate()
    }
  }

  async onFileSelected(event) {
    const file: File = <File>event.target.files[0];
    const fd: FormData = new FormData();

    fd.append('image', file, file.name);

    this.imageService
      .post(fd)
      .subscribe((response) => (this.imageValue = response));
  }
}
