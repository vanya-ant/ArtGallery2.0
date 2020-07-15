import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {ArtistsComponent} from '../artists/artists-list/artists.component';
import {ArtistCreateComponent} from '../artists/artist-create/artist-create.component';
import {AuthGuard} from '../auth/auth.guard';
import {ArtistDetailsComponent} from '../artists/artist-details/artist-details.component';
import {ArticlesAllComponent} from './articles-all/articles-all.component';
import {ArticleCreateComponent} from './article-create/article-create.component';

const routes: Routes = [
  { path: '', component: ArticlesAllComponent },
  { path: 'create', component: ArticleCreateComponent, canActivate: [AuthGuard] },
  { path: ':id', component: ArtistDetailsComponent },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class BlogRoutingModule { }
