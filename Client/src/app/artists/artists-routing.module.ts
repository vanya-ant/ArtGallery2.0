import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../auth/auth.guard';
import {ArtistsComponent} from './artists-list/artists.component';
import {ArtistCreateComponent} from './artist-create/artist-create.component';
import {ArtistDetailsComponent} from './artist-details/artist-details.component';

const routes: Routes = [
  { path: '', component: ArtistsComponent },
  { path: 'create', component: ArtistCreateComponent, canActivate: [AuthGuard] },
  { path: ':id', component: ArtistDetailsComponent },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ArtistsRoutingModule { }
