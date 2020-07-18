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
  itemsPath: string = environment.itemsApiUrl;
  itemsPathWithoutSlash  = this.itemsPath.slice(0, -1);

  constructor(
    private http: HttpClient
  ) { }

  getItems(): Observable<Array<IItem>> {
    return this.http.get<Array<IItem>>(this.itemsPath);
  }

  getItem(id: string): Observable<IItem> {
    return this.http.get<IItem>(this.itemsPath + id);
  }

  createItem(item: IItem): Observable<IItem> {
    return this.http.post<IItem>(this.itemsPath, item);
  }

  editItem(id: string, item: IItem): Observable<IItem> {
    return this.http.put<IItem>(this.itemsPath + id, item);
  }

  deleteItem(id: string) {
    return this.http.delete(this.itemsPath + id);
  }

  search(queryString): Observable<Array<IItem>> {

    return this.http.get<Array<IItem>>(this.itemsPathWithoutSlash + queryString);
  }

  sort(queryString): Observable<Array<IItem>> {
    return this.http.get<Array<IItem>>(this.itemsPathWithoutSlash + queryString);
  }
}
