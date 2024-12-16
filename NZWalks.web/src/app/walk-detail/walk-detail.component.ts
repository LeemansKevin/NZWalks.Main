import { Component, inject, Input, input } from '@angular/core';
import { GetWalkDTO } from '../../models/getWalkDTO';
import { WalkService } from '../../services/walk.service';
import { error } from 'console';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-walk-detail',
  standalone: false,

  templateUrl: './walk-detail.component.html',
  styleUrl: './walk-detail.component.scss',
})
export class WalkDetailComponent {
  walkId: number = -1
  @Input() dto: GetWalkDTO | null = null;

  constructor(private walkService: WalkService, private route:ActivatedRoute) {}

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    if (this.dto === null) {
      this.walkId = Number(this.route.snapshot.paramMap.get('id'));
      this.walkService.getWalk(this.walkId).subscribe({
        next: (data) => {
          this.dto = data;
        },
        error: (error) => {
          console.error(error);
        },
      });
    }
  }
}
