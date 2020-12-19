import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { ImageService } from '../../services/image/image.service';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss'],
})
export class EmployeeInfoComponent implements OnInit {
  employee: Employee;
  imageValue: Image;
  formValues: FormGroup;

  constructor(
    public activeModal: NgbActiveModal,
    private readonly imageService: ImageService
  ) {}

  ngOnInit(): void {
    this.imageValue = this.employee.picture;
    this.formValues = new FormGroup({
      employeeId: new FormControl(this.employee.employeeId, [
        Validators.required,
      ]),
      name: new FormControl(this.employee.name, [Validators.required]),
      phone: new FormControl(this.employee.phoneNumber, [
        Validators.required,
        Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-s./0-9]*$'),
      ]),
      email: new FormControl(this.employee.email, [
        Validators.required,
        Validators.email,
      ]),
      hire: new FormControl(this.employee.hireDate, [Validators.required]),
      managerId: new FormControl(this.employee.managerId),
    });
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
