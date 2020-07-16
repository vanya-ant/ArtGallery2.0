import { Component, OnInit } from '@angular/core';
import { IArtist } from '../../shared/artist';

@Component({
  selector: 'app-artists',
  templateUrl: './artist-list.html',
  styleUrls: ['./artist-list.component.scss']
})
export class ArtistListComponent implements OnInit {

  artists: IArtist[] = [];
  artist: IArtist;

  constructor() { }

  ngOnInit(): void {
  }

}
