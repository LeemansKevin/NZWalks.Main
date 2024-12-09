import { Component, inject } from '@angular/core';
import { GetWalkDTO } from '../../models/getWalkDTO';
import { WalkService } from '../../services/walk.service';
import { error } from 'console';


@Component({
  selector: 'app-walk-detail',
  standalone: false,

  templateUrl: './walk-detail.component.html',
  styleUrl: './walk-detail.component.scss'
})
export class WalkDetailComponent {

  dto: GetWalkDTO | null = null

  constructor(private walkService: WalkService) { }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.walkService.getWalk(1).subscribe({
      next: (data) => {
        (this.dto = data)
        
      },
      error: (error) => {
        console.error(error)
      }
    })
  }

}
