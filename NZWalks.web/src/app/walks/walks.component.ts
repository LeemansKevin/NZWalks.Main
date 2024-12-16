import { Component } from '@angular/core';
import { WalkService } from '../../services/walk.service';
import { GetWalkDTO } from '../../models/getWalkDTO';

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
        (this.dtos = data)
        console.log(data)
      },
      error: (error) => {
        console.error(error)
      }
    })
  }
}
