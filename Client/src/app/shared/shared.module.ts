import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SortingPipe } from './sorting.pipe';
import { SearchPipe } from './search.pipe';



@NgModule({
  declarations: [SortingPipe, SearchPipe],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
