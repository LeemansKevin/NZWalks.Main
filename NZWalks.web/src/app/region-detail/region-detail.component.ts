import { Component } from '@angular/core';
import { GetRegionWithWalksDTO } from '../../models/getRegionWithWalksDTO';
import { RegionService } from '../../services/region.service';

@Component({
  selector: 'app-region-detail',
  standalone: false,
  
  templateUrl: './region-detail.component.html',
  styleUrl: './region-detail.component.scss'
})
export class RegionDetailComponent {

  dto: GetRegionWithWalksDTO | null = null

  constructor (private regionService: RegionService) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.regionService.getRegionWithWalks().subscribe({
      next: (data) => {
        (this.dto = data)
        
      },
      error: (error) => {
        console.error(error)
      }
    })
  }

  
}
