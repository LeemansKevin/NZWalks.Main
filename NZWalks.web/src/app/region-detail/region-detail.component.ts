import { Component } from '@angular/core';
import { GetRegionWithWalksDTO } from '../../models/getRegionWithWalksDTO';
import { RegionService } from '../../services/region.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-region-detail',
  standalone: false,
  
  templateUrl: './region-detail.component.html',
  styleUrl: './region-detail.component.scss'
})
export class RegionDetailComponent {
  regionId: number = -1
  dto: GetRegionWithWalksDTO | null = null

  constructor (private regionService: RegionService, private route:ActivatedRoute) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.regionId = Number( this.route.snapshot.paramMap.get('id'));
    this.regionService.getRegionWithWalks(this.regionId).subscribe({
      next: (data) => {
        (this.dto = data)
        
      },
      error: (error) => {
        console.error(error)
      }
    })
  }

  
}
