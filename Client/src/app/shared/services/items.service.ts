import { Injectable } from '@angular/core';
import { IItem } from '../item';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  item: IItem;
  itemssPath: string = environment.apiUrl + 'items/';
  itemssPathWithoutSlash  = this.itemssPath.slice(0, -1);

  constructor(
    private http: HttpClient
  ) { }

  getItems(): Observable<Array<IItem>> {
    return this.http.get<Array<IItem>>(this.itemssPath);
  }

  getItem(id: string): Observable<IItem> {
    return this.http.get<IItem>(this.itemssPath + id);
  }

  createItem(item: IItem): Observable<IItem> {
    return this.http.post<IItem>(this.itemssPath, item);
  }

  editItem(id: string, item: IItem): Observable<IItem> {
    return this.http.put<IItem>(this.itemssPath + id, item);
  }

  deleteItem(id: string) {
    return this.http.delete(this.itemssPath + id);
  }

  search(queryString): Observable<Array<IItem>> {

    return this.http.get<Array<IItem>>(this.itemssPathWithoutSlash + queryString);
  }

  sort(queryString): Observable<Array<IItem>> {
    return this.http.get<Array<IItem>>(this.itemssPathWithoutSlash + queryString);
  }

  changeAvailability(id): Observable<boolean> {
    return this.http.put<boolean>(this.itemssPath + id + '/ChangeAvailability', {});
  }
}
