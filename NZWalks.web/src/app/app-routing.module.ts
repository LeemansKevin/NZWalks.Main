import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HelloComponent } from './hello/hello.component';
import { WalksComponent } from './walks/walks.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegionDetailComponent } from './region-detail/region-detail.component';
import { WalkDetailComponent } from './walk-detail/walk-detail.component';

const routes: Routes = [
  { path: '', component: HelloComponent },
  { path: 'walks', component: WalksComponent },
  { path: 'walk/:id', component:WalkDetailComponent},
  { path: 'region/:id',component: RegionDetailComponent},
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
