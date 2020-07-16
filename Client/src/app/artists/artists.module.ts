import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistListComponent } from './artist-list/artist-list.component';
import { ArtistCreateComponent } from './artist-create/artist-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ArtistDetailsComponent } from './artist-details/artist-details.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ArtistListComponent, ArtistCreateComponent, ArtistDetailsComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule
    ]
})
export class ArtistsModule { }
