import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../auth/auth.guard';
import {ArtistListComponent} from './artist-list/artist-list.component';
import {ArtistCreateComponent} from './artist-create/artist-create.component';
import {ArtistDetailsComponent} from './artist-details/artist-details.component';

const routes: Routes = [
  { path: '', component: ArtistListComponent },
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
