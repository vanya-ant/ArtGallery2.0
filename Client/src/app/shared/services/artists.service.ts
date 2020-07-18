import { Injectable } from '@angular/core';
import {IItem} from '../item';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IArtist} from '../artist';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {
  artistPath: string = environment.artistsPath;
  artistPathWithoutSlash  = this.artistPath.slice(0, -1);

  constructor(
    private http: HttpClient
  ) { }

  getArtists(): Observable<Array<IArtist>> {
    return this.http.get<Array<IArtist>>(this.artistPath);
  }

  getArtist(id: string): Observable<IArtist> {
    return this.http.get<IArtist>(this.artistPath + id);
  }

  createArtist(artist: IArtist): Observable<IArtist> {
    return this.http.post<IArtist>(this.artistPath, artist);
  }

  editArtist(id: string, artist: IArtist): Observable<IArtist> {
    return this.http.put<IArtist>(this.artistPath + id, artist);
  }

  deleteArtist(id: string) {
    return this.http.delete(this.artistPath + id);
  }

  search(queryString): Observable<Array<IItem>> {

    return this.http.get<Array<IItem>>(this.artistPathWithoutSlash + queryString);
  }
}
