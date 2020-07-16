import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../auth/auth.guard';
import {ArticleListComponent} from './article-list/article-list.component';
import {ArticleCreateComponent} from './article-create/article-create.component';
import {ArticleDetailsComponent} from './article-details/article-details.component';

const routes: Routes = [
  { path: '', component: ArticleListComponent },
  { path: 'create', component: ArticleCreateComponent, canActivate: [AuthGuard] },
  { path: ':id', component: ArticleDetailsComponent },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class BlogRoutingModule { }
