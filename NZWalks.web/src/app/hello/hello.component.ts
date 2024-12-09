import { Component } from '@angular/core';

@Component({
  selector: 'app-hello',
  standalone: false,

  templateUrl: './hello.component.html',
  styleUrl: './hello.component.scss'
})
export class HelloComponent {
  firstName: string = 'William'
  lastName: string = 'Jeanray'
  fullName: string = ''

  concatenateNames() {
    this.fullName = `Volledige naam: ${this.firstName} ${this.lastName}`;
  }
}
