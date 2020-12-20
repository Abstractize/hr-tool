import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog-information',
  templateUrl: './dialog-information.component.html',
})
/**
 * Modal or Popup that shows information.
 */
export class DialogInformationComponent implements OnInit {
  @Input() title: string = '';
  @Input() body: string = '';
  @Input() needsConfirmation = false;
  /**
   * Creates a Popup that informs.
   * @param activeModal Modal that is activated at the moment.
   */
  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {}
}
