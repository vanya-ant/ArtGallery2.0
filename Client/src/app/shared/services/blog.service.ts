import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {IArticle} from '../article';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  blogPath: string = environment.blogApiUrl;
  blogPathWithoutSlash  = this.blogPath.slice(0, -1);

  constructor(private http: HttpClient) { }

  getArticles(): Observable<Array<IArticle>> {
    return this.http.get<Array<IArticle>>(this.blogPath);
  }

  getArticle(id: string): Observable<IArticle> {
    return this.http.get<IArticle>(this.blogPath + id);
  }

  createArticle(article: IArticle): Observable<IArticle> {
    return this.http.post<IArticle>(this.blogPath, article);
  }

  editArticle(id: string, article: IArticle): Observable<IArticle> {
    return this.http.put<IArticle>(this.blogPath + id, article);
  }

  deleteArticle(id: string) {
    return this.http.delete(this.blogPath + id);
  }
}
