import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog-information',
  templateUrl: './dialog-information.component.html',
})
export class DialogInformationComponent implements OnInit {
  @Input() title: string = '';
  @Input() body: string = '';
  @Input() needsConfirmation = false;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

}
