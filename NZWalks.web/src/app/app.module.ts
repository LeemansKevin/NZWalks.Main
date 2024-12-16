import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HelloComponent } from './hello/hello.component';
import { WalkDetailComponent } from './walk-detail/walk-detail.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RegionDetailComponent } from './region-detail/region-detail.component';
import { WalksComponent } from './walks/walks.component';

@NgModule({
  declarations: [
    AppComponent,
    HelloComponent,
    WalkDetailComponent,
    RegionDetailComponent,
    WalksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [
    provideClientHydration(withEventReplay())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
