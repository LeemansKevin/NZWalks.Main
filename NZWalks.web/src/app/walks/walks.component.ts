import { Component } from '@angular/core';
import { WalkService } from '../../services/walk.service';
import { GetWalkDTO } from '../../models/getWalkDTO';
import { AddWalkDTO } from '../../models/addWalkDTO';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-walks',
  standalone: false,

  templateUrl: './walks.component.html',
  styleUrl: './walks.component.scss',
})
export class WalksComponent {
  dtos: GetWalkDTO[] = [];

  constructor(private service: WalkService) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.service.getWalks().subscribe({
      next: (data) => {
        this.dtos = data;
        console.log(data);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  dto: AddWalkDTO = {
    Name: 'Mountain Adventure 2',
    Description: 'A beautiful mountain walk.',
    LengthInKm: 15.5,
    Altitude: 2500,
    PictureUrl: 'https://example.com/mountain.jpg',
    RegionId: 3,
  };

  // dto: AddWalkDTO = {
  //     Name: '',
  //     Description: '',
  //     LengthInKm: -12.5,
  //     Altitude: -1500,
  //     PictureUrl: '',
  //     RegionId: 986558,
  //   };

  addWalk(): void {

    this.service.addWalk(this.dto).subscribe({
      next: () => {
        alert('wandeling toegevoegd');
      },
      error: (error: HttpErrorResponse) => {
        if (error.status === 400 && error.error.errors) {
          // Handle validation errors and log them to the console
          const backendErrors = error.error.errors;
          console.error('Backend validation errors:', backendErrors);

          // Optionally, you can loop through the backend errors and log each message
          Object.keys(backendErrors).forEach((key) => {
            console.error(`${key}: ${backendErrors[key].join(', ')}`);
          });
        } else {
          console.error('Error adding walk:', error);
        }
      },
    });
  }
}
