import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleDetailsComponent } from './article-details/article-details.component';
import { ArticleCreateComponent } from './article-create/article-create.component';
import {ArticleListComponent} from './article-list/article-list.component';



@NgModule({
  declarations: [ArticleListComponent, ArticleDetailsComponent, ArticleCreateComponent],
  imports: [
    CommonModule
  ]
})
export class BlogModule { }
