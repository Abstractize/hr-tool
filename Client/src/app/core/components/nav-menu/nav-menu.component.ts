import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
/**
 * Component that contents the Navegation Bar.
 */
export class NavMenuComponent {
  isExpanded = false;
  /**
   * Collapses the navegation bar.
   */
  collapse() {
    this.isExpanded = false;
  }
  /**
   * Toggles the navegation bar.
   */
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
