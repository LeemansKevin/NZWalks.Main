import { Component, inject, Input, input } from '@angular/core';
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

 @Input() dto: GetWalkDTO | null = null

  

}
